
from predict_office.prediction_case import TPredictionCase

import json
import random
from sklearn.model_selection import train_test_split
import csv
import operator


class TOfficePool:
    UNKNOWN_OFFICE_ID = 1234567890

    def __init__(self, logger, office_index=None, max_errors_count=10):
        self.pool = list()
        self.logger = logger
        self.office_index = office_index
        self.max_errors_count = max_errors_count

    def _read_line(self, line):
        sha256, web_domain, office_id, office_strings = line.strip().split("\t")
        if office_id == 'None':
            office_id = None
        else:
            if int(office_id) == self.UNKNOWN_OFFICE_ID:
                self.logger.debug("skip {} (unknown office id)".format(sha256))
                return
            office_id = int(office_id)

        case = TPredictionCase(self.office_index, sha256, web_domain, office_id, office_strings)
        if len(case.text) == 0:
            self.logger.debug("skip {} (empty text)".format(sha256))
            return
        if len(case.web_domain) == 0:
            self.logger.debug("skip {} (empty web domain)".format(sha256))
            return

        self.pool.append(case)

    def read_cases(self, file_name: str, row_count=None, make_uniq=False):
        cnt = 0
        error_cnt = 0
        already = set()
        with open(file_name, "r") as inp:
            for line in inp:
                if make_uniq:
                    if hash(line) in already:
                        self.logger.debug("skip {} (a copy found)".format(sha256))
                        continue
                    already.add(hash(line))

                try:
                    self._read_line(line)
                    cnt += 1
                    if row_count is not None and cnt >= row_count:
                        break
                except ValueError as err:
                    self.logger.debug("cannot parse line {}, skip it".format(line.strip()))
                    error_cnt += 1
                    if error_cnt > self.max_errors_count:
                        raise Exception("too many errors (>{})".format(self.max_errors_count))
                    pass
        self.logger.info("read {} cases from {}".format(cnt, file_name))

    @staticmethod
    def write_pool(cases, output_path):
        c: TPredictionCase
        with open(output_path, "w") as outp:
            for c in cases:
                outp.write("{}\n".format("\t".join([c.sha256, c.web_domain,  str(c.true_office_id), c.office_strings])))

    def split(self, train_pool_path, test_pool_path, test_size=0.2):
        random.shuffle(self.pool)
        if test_pool_path is not None:
            train, test = train_test_split(self.pool, test_size=test_size)
            self.write_pool(train, train_pool_path)
            self.write_pool(test, test_pool_path)
            self.logger.info("train size = {}, test size = {}".format(len(train), len(test)))
        else:
            self.write_pool(self.pool, train_pool_path)
            self.logger.info("train size = {}".format(len(self.pool)))

    def build_toloka_pool(self,  test_y_pred, output_path, format: int):
        assert len(self.pool) == len(test_y_pred)
        assert format == 1 or format == 2

        with open(output_path, "w") as outp:
            case: TPredictionCase
            cnt = 0
            tsv_writer = csv.writer(outp, delimiter="\t")
            for case, pred_proba_y in zip(self.pool, test_y_pred):
                hypots = dict()
                calculated_office_id = case.true_office_id
                if calculated_office_id is None:
                    site_info = self.office_index.web_sites.get_first_site_by_web_domain(case.web_domain)
                    if site_info is not None:
                        calculated_office_id = site_info.parent_office.office_id
                    else:
                        self.logger.error("cannot find web domain {} in data/offices.txt, please, update it".format(case.web_domain))

                if calculated_office_id is not None:
                    hypots[calculated_office_id] = 1

                learn_target, weight = max(enumerate(pred_proba_y), key=operator.itemgetter(1))
                max_office_id = self.office_index.get_office_id_by_ml_office_id(learn_target)
                hypots[max_office_id] = float(weight)

                if calculated_office_id != max_office_id:
                    for ml_office_id, weight in enumerate(pred_proba_y):
                        if weight > 0.1:
                            office_id = self.office_index.get_office_id_by_ml_office_id(ml_office_id)
                            hypots[office_id] = weight

                office_infos = list()
                index = 1
                for office_id, weight in sorted(hypots.items(), key=operator.itemgetter(1), reverse=True):
                    region_id = self.office_index.get_office_region(office_id)
                    if region_id is not None:
                        region_str = self.office_index.regions.get_region_by_id(region_id).name
                    else:
                        region_str = "none"

                    rec =  {
                        'hypot_office_id': int(office_id),
                        'hypot_office_name': self.office_index.get_office_name(office_id),
                        'hypot_region': region_str,
                        "weight": round(float(weight), 4),
                        "index": str(index)
                    }
                    if len(hypots) == 1:
                        rec['status'] = "true_positive"
                    if office_id == calculated_office_id:
                        rec['calculated_office_id'] = 1
                    index += 1
                    office_infos.append(rec)
                office_strings = json.loads(case.office_strings)
                web_domain_title = self.office_index.web_sites.get_title_by_web_domain(case.web_domain)
                if web_domain_title is None or len (web_domain_title) == 0:
                    web_domain_title = "_"
                rec = {
                    "INPUT:sha256":  case.sha256,
                    "INPUT:web_domain": (case.web_domain if format == 1 else "http://" + case.web_domain),
                    "INPUT:web_domain_title": web_domain_title
                }
                if format == 1:
                    add_rec = {

                        'INPUT:doc_title': office_strings.get('title', ''),
                        'INPUT:doc_roles': ";".join(office_strings.get('roles', [])),
                        'INPUT:doc_departments': ";".join(office_strings.get('departments', [])),
                        'INPUT:office_hypots': json.dumps(office_infos, ensure_ascii=False),
                    }
                elif format == 2:
                    hypots_str = json.dumps(office_infos, ensure_ascii=False).strip('[]').replace(',', '\\,')
                    of_str = {
                                'title': office_strings.get('title', ''),
                                'roles': ";".join(office_strings.get('roles', [])),
                                'departments':  ";".join(office_strings.get('departments', []))
                        }
                    add_rec = {
                        "INPUT:web_domain_title": web_domain_title,
                        'INPUT:office_strings': json.dumps(of_str, ensure_ascii=False),
                        'INPUT:office_hypots': hypots_str
                    }
                rec.update(add_rec)
                if cnt == 0:
                    tsv_writer.writerow(list(rec.keys()))
                tsv_writer.writerow(list(rec.values()))
                cnt += 1
