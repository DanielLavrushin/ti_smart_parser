from django.db import models
from django.utils.translation import  get_language
from .countries import get_country_str
from .rubrics import get_russian_rubric_str
from declarations.nominal_income import get_average_nominal_incomes

from collections import defaultdict
from operator import attrgetter

def get_django_language():
    lang = get_language().lower()
    if len(lang) > 2:
        lang = lang[:2]
    return lang


class Office(models.Model):
    name = models.TextField(verbose_name='office name')
    region_id = models.IntegerField(null=True)
    type_id = models.IntegerField(null=True)
    parent_id = models.IntegerField(null=True)
    rubric_id = models.IntegerField(null=True, default=None) # see TOfficeRubrics

    @property
    def source_document_count(self):
        try:
            return self.source_document_set.all().count()
        except Exception as exp:
            raise

    def get_source_documents(self, max_count=10):
        cnt = 0
        for src_doc in self.source_document_set.all():
            yield src_doc.id
            cnt += 1
            if cnt >= max_count:
                break

    @property
    def source_documents(self):
        return self.get_source_documents(max_count=10)

    @property
    def parent_office_name(self):
        if self.parent_id is None:
            return ""
        return Office.objects.get(pk=self.parent_id).name

    @property
    def child_offices_count(self):
        return Office.objects.all().filter(parent_id=self.id).count()

    def get_child_offices(self, max_count=5):
        if self.parent_id is None:
            return ""
        cnt = 0
        for x in Office.objects.all().filter(parent_id=self.id):
            yield x.id, x.name
            cnt += 1
            if  cnt >= max_count:
                break

    @property
    def child_offices(self):
        return self.get_child_offices(max_count=5)

    @property
    def rubric_str(self):
        if self.rubric_id is None:
            return "unknown"
        else:
            return get_russian_rubric_str(self.rubric_id)


class Region(models.Model):
    name = models.TextField(verbose_name='region name')
    wikibase_id = models.CharField(max_length=10, null=True)


class SynonymClass:
    Russian = 0
    English = 1
    EnglishShort = 2
    RussianShort = 3


class Region_Synonyms(models.Model):
    region = models.ForeignKey('declarations.Region', verbose_name="region", on_delete=models.CASCADE)
    synonym = models.TextField(verbose_name='region synonym')
    synonym_class = models.IntegerField(null=True) #see SynonymClass


class TOfficeTableInMemory:
    group_types = set([10, 12, 16, 17]) # this offices do not exist like all Moscow courts

    def go_to_the_top(self, id):
        cnt = 0
        while True:
            cnt += 1
            if cnt > 5:
                raise Exception("too deep structure, probably a cycle found ")
            if self.offices[id]['parent_id'] is None:
                return id
            parent = self.offices[self.offices[id]['parent_id']]
            if self.use_office_types:
                if parent['type_id'] in TOfficeTableInMemory.group_types:
                    return id
            id = parent['id']
        return id

    def get_parent_office(self, office_id):
        return self.transitive_top[int(office_id)]

    def __init__(self, use_office_types=True, init_from_json=None):
        self.use_office_types = use_office_types
        self.offices = dict()
        self.transitive_top = dict()
        if init_from_json is None:
            for o in Office.objects.all():
                self.offices[o.id] = {
                     'id': o.id,
                     'name': o.name,
                     'parent_id': o.parent_id,
                     'type_id': o.type_id,
                     'rubric_id': o.rubric_id
                }
        else:
            for o in init_from_json:
                self.offices[o['id']] = o

        for office_id in self.offices:
            self.transitive_top[office_id] = self.go_to_the_top(office_id)


class Relative:
    main_declarant_code = "D"
    spouse_code = "S"
    child_code = "C"
    unknown_code = "?"
    code_to_info = dict()
    russian_to_code = dict()

    @staticmethod
    def get_relative_code(russian_name):
        if russian_name is None:
            return Relative.main_declarant_code
        r = russian_name.strip(" \n\r\t").lower()
        return Relative.russian_to_code.get(r, Relative.unknown_code)

    @staticmethod
    def static_initalize():
        Relative.code_to_info = {
            Relative.main_declarant_code:  {"ru": "", "en": "", "visual_order": 0},  # main public servant
            Relative.spouse_code: {"ru": "супруг(а)", "en": "spouse", "visual_order": 1},
            Relative.child_code: {"ru": "ребенок", "en": "child", "visual_order": 2},
            Relative.unknown_code: {"ru": "иное", "en": "other", "visual_order": 3},
        }
        Relative.russian_to_code = dict(((value['ru'], key) for key, value in Relative.code_to_info.items()))

    def __init__(self, code):
        self.code = code

    @property
    def name(self):
        info = Relative.code_to_info[self.code]
        return info.get(get_django_language(), info.get("en"))

    def __hash__(self):
        return ord(self.code)

    def __eq__(self, other):
        return self.code == other.code

    @staticmethod
    def sort_by_visual_order(items):
        if len(items) == 0:
            return items
        return sorted(items, key=(lambda x: Relative.code_to_info[x.code]['visual_order']))


Relative.static_initalize()


class OwnType:
    property_code = "P"
    code_to_info = dict()
    russian_to_code = dict()

    @staticmethod
    def get_own_type_code(russian_name):
        if russian_name is None:
            return OwnType.property_code
        r = russian_name.strip(" \n\r\t").lower()
        return OwnType.russian_to_code.get(r, OwnType.property_code)


    @staticmethod
    def static_initalize():
        OwnType.code_to_info = {
            OwnType.property_code: {"ru": "В собственности", "en": "private"},
            "U": {"ru": "В пользовании", "en": "in use"},
            "?": {"ru": "иное", "en": "other"},
        }
        OwnType.russian_to_code = dict((value['ru'], key) for key, value in OwnType.code_to_info.items())


OwnType.static_initalize()


class Web_Reference(models.Model):
    source_document = models.ForeignKey('declarations.source_document', verbose_name="source document", on_delete=models.CASCADE)
    dlrobot_url = models.TextField(null=True)
    crawl_epoch = models.IntegerField(null=True)
    web_domain = models.TextField(null=True)


class Declarator_File_Reference(models.Model):
    source_document = models.ForeignKey('declarations.source_document', verbose_name="source document",
                                 on_delete=models.CASCADE)
    declarator_documentfile_id = models.IntegerField(null=True)
    declarator_document_id = models.IntegerField(null=True)
    declarator_document_file_url = models.TextField(null=True)
    web_domain = models.TextField(null=True)


class Source_Document(models.Model):
    id = models.IntegerField(primary_key=True)
    office = models.ForeignKey('declarations.Office', verbose_name="office name", on_delete=models.CASCADE)
    sha256 = models.CharField(max_length=200)
    file_extension = models.CharField(max_length=16)
    intersection_status = models.CharField(max_length=16)

    # calculated fields (from sql table section)
    min_income_year = models.IntegerField(null=True, default=None)
    max_income_year = models.IntegerField(null=True, default=None)
    section_count = models.IntegerField(null=True, default=0)

    def permalink_passports(self):
        yield "sd;{}".format(self.sha256)


class Person(models.Model):
    id = models.IntegerField(primary_key=True)
    person_name = models.CharField(max_length=64, verbose_name='person name')
    declarator_person_id = models.IntegerField(null=True)

    @property
    def section_count(self):
        return self.section_set.all().count()

    @property
    def last_position_and_office_str(self):
        last_section = max( (s for s in self.section_set.all()), key=attrgetter("income_year"))
        str = last_section.source_document.office.name

        position_and_department = ""
        if last_section.department is not None:
            position_and_department += last_section.department

        if last_section.position is not None:
            if position_and_department != "":
                position_and_department += ", "
            position_and_department += last_section.position

        if position_and_department != "":
            str += " ({})".format(position_and_department)
        return str

    @property
    def declaraion_count_str(self):
        cnt = len(self.section_set.all())
        if cnt == 1:
            return "{} декларация".format(cnt)
        elif cnt < 5:
            return "{} декларации".format(cnt)
        else:
            return "{} деклараций".format(cnt)

    @property
    def years_str(self):
        years = list(s.income_year for s in self.section_set.all())
        years.sort()
        if len(years) == 1:
            return "{} год".format(years[0])
        else:
            return "{} годы".format(", ".join(map(str, years)))

    @property
    def sections_ordered_by_year(self):
        return list(sorted(self.section_set.all(), key=attrgetter("income_year")))

    def income_growth_yearly(self):
        sections = self.sections_ordered_by_year
        years = list(s.income_year for s in sections)
        incomes = list(s.get_declarant_income_size() for s in sections)
        return get_average_nominal_incomes(years, incomes)

    def permalink_passports(self):
        if hasattr(self, "tmp_section_set"):
            sections = self.tmp_section_set
        else:
            sections = list(str(s.id) for s in self.section_set.all())
            sections.sort()
        if len(sections) > 0:
            #a person without sections exists before  saving to the db in copy_person_id.py
            yield "ps;" + ";".join(sections)
        else:
            assert self.declarator_person_id is not None

        if self.declarator_person_id is not None:
            yield "psd;" + str(self.declarator_person_id)


class RealEstate(models.Model):
    section = models.ForeignKey('declarations.Section', on_delete=models.CASCADE)
    type = models.TextField(verbose_name='real_estate')
    country = models.CharField(max_length=2)
    relative = models.CharField(max_length=1)
    owntype = models.CharField(max_length=1)
    square = models.IntegerField(null=True)
    share = models.FloatField(null=True)

    @property
    def own_type_str(self):
        info = OwnType.code_to_info[self.owntype]
        return info.get(get_django_language(), info.get("en"))

    @property
    def country_str(self):
        return get_country_str(self.country, get_django_language())


class Vehicle(models.Model):
    section = models.ForeignKey('declarations.Section', on_delete=models.CASCADE)
    relative = models.CharField(max_length=1)
    name = models.TextField()


class Income(models.Model):
    section = models.ForeignKey('declarations.Section', on_delete=models.CASCADE)
    size = models.IntegerField(null=True)
    relative = models.CharField(max_length=1)


def get_relatives(records):
    return set( Relative(x.relative) for x in records.all())


class Section(models.Model):
    id = models.IntegerField(primary_key=True)
    source_document = models.ForeignKey('declarations.source_document', null=True, verbose_name="source document", on_delete=models.CASCADE)
    person = models.ForeignKey('declarations.Person', null=True, verbose_name="person id", on_delete=models.CASCADE)
    person_name = models.CharField(max_length=64, verbose_name='person name')
    income_year = models.IntegerField(null=True)
    department = models.TextField(null=True)
    position = models.TextField(null=True)
    dedupe_score = models.FloatField(blank=True, null=True, default=0.0)
    surname_rank = models.IntegerField(null=True)
    name_rank = models.IntegerField(null=True)
    rubric_id = models.IntegerField(null=True, default=None)  # see TOfficeRubrics

    @property
    def section_parts(self):
        relatives = set()
        relatives.add(Relative(Relative.main_declarant_code))
        relatives |= get_relatives(self.income_set)
        relatives |= get_relatives(self.realestate_set)
        relatives |= get_relatives(self.vehicle_set)
        relative_list = Relative.sort_by_visual_order(list(relatives))
        return relative_list

    def get_surname_rank(self):
        return self.surname_rank if self.surname_rank is not None else 100

    def get_name_rank(self):
        return self.name_rank if self.name_rank is not None else 100

    def get_declarant_income_size(self):
        if hasattr(self, "tmp_income_set"):
            incomes = self.tmp_income_set # used during the main section import
        else:
            incomes = self.income_set.all()
        for i in incomes:
            if i.relative == Relative.main_declarant_code:
                return i.size
        return 0

    @property
    def declarant_income_size(self):
        return self.get_declarant_income_size()

    def permalink_passports(self):
        main_income = self.get_declarant_income_size()
        yield "sc;{};{};{};{}".format(self.source_document.id, self.person_name.lower(), self.income_year, main_income)

    @property
    def rubric_str(self):
        if self.rubric_id is None:
            return "unknown"
        else:
            return get_russian_rubric_str(self.rubric_id)

    @staticmethod
    def describe_realty(r: RealEstate):
        if r is None:
            return ["", "", ""]
        type_str = r.type
        if r.country != "RU":
            type_str += " ({})".format(r.country_str)
        return [type_str, str(r.square), r.own_type_str]

    @property
    def realty_square_sum(self):
        sum = 0
        for r in self.realestate_set.all():
            sum += r.square
        return sum

    @property
    def vehicle_count(self):
        return len(list(self.vehicle_set.all()))

    @property
    def html_table_data_rows(self):
        secton_parts = self.section_parts

        realties = defaultdict(list)
        for r in self.realestate_set.all():
            realties[r.relative].append(Section.describe_realty(r))
        for x in secton_parts:
            if len(realties[x.code]) == 0:
                realties[x.code].append(Section.describe_realty(None))

        vehicles = defaultdict(str)
        for v in self.vehicle_set.all():
            vehicles[v.relative] += v.name + "<br/>"

        incomes = defaultdict(str)
        for i in self.income_set.all():
            incomes[i.relative] = str(i.size)

        table = list()
        for relative in secton_parts:
            cnt = 0
            for (realty_type, realty_square, own_type) in realties[relative.code]:
                if cnt == 0:
                    rowspan = len(realties[relative.code])
                    if relative.code == Relative.main_declarant_code:
                        cells = [(self.person_name, rowspan), (self.position, rowspan)]
                    else:
                        cells = [(relative.name, rowspan), ("", rowspan)]
                    cells.extend([(realty_type, 1), (realty_square, 1), (own_type, 1),
                                  (vehicles[relative.code], rowspan), (incomes[relative.code], rowspan)])
                else:
                    cells = [(realty_type, 1), (realty_square, 1), (own_type, 1)]
                cnt += 1
                table.append(cells)
        return table