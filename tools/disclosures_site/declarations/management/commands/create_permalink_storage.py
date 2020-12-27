from declarations.management.commands.permalinks import TPermaLinksDB
from common.primitives import queryset_iterator
import declarations.models as models

from django.core.management import BaseCommand
import logging
import os


def setup_logging(logfilename="create_permalink_storage.log"):
    logger = logging.getLogger("copy_primary_keys")
    logger.setLevel(logging.DEBUG)

    # create formatter and add it to the handlers
    formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')
    if os.path.exists(logfilename):
        os.remove(logfilename)
    # create file handler which logs even debug messages
    fh = logging.FileHandler(logfilename, encoding="utf8")
    fh.setLevel(logging.DEBUG)
    fh.setFormatter(formatter)
    logger.addHandler(fh)

    return logger


class Command(BaseCommand):
    help = 'create permalink storage (in gnu.dmb format) to make web links almost permanent'

    def __init__(self, *args, **kwargs):
        super(Command, self).__init__(*args, **kwargs)
        self.options = None

    def add_arguments(self, parser):
        parser.add_argument(
                '--output-dbm-file',
            dest='output_dbm_file',
            default=None,
            required=True,
            help='write mapping to this fiie'
        )

    def save_permalinks(self, logger, django_db_model, db: TPermaLinksDB):
        if django_db_model.objects.count() == 0:
            db.save_max_plus_one_primary_key(django_db_model, 0)
        else:
            cnt = 0
            max_value = 0
            for record in queryset_iterator(django_db_model.objects.all()):
                cnt += 1
                if (cnt % 3000) == 0:
                    logger.debug("{}:{}".format(str(django_db_model), cnt))
                db.put_record_id(record)
                max_value = max(record.id, max_value)

            db.save_max_plus_one_primary_key(django_db_model, max_value + 1)

    def handle(self, *args, **options):
        logger = setup_logging()

        db = TPermaLinksDB(options.get('output_dbm_file'))
        db.create_db()
        self.save_permalinks(logger, models.Source_Document, db)
        db.sync_db()
        self.save_permalinks(logger, models.Section, db)
        db.sync_db()
        self.save_permalinks(logger, models.Person, db)
        db.close_db()

        logger.info("all done")

CreatePermalinksStorage=Command
