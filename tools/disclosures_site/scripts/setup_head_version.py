import os.path
import sys
import argparse

from common.logging_wrapper import setup_logging


def parse_args():
    parser = argparse.ArgumentParser()
    parser.add_argument("--mysql-version", dest='mysql_version')
    parser.add_argument("--elasticsearch-version", dest='elasticsearch_version')
    return parser.parse_args()


class TUpdater:
    def __init__(self):
        self.logger = setup_logging("source_updater")
        self.parser = parse_args()

    def run_cmd(self, cmd):
        self.logger.info(cmd)
        exit_value = os.system(cmd)
        if exit_value != 0:
            raise Exception("{} failed".format(cmd))

    def check_version(self, service, expected_version):
        self.run_cmd('sudo {} --version > /tmp/version'.format(service))
        with open('/tmp/version') as inp:
            v = inp.read()
            if v != expected_version:
                raise Exception("Service {}, backend version = {}, prod version = {}".format(service, expected_version,
                                                                                             v))

    def main(self):
        disclosures_folder = os.path.join(os.path.dirname(__file__), "..")
        os.chdir(disclosures_folder)

        self.run_cmd('sudo ls >/dev/null')          #check sudo without password
        self.check_version('mysqld', self.args.mysql_version)
        self.check_version('/usr/share/elasticsearch/bin/elasticsearch', self.args.elasticsearch_version)
        self.run_cmd('git log .. -n 1  >> last_commits.txt')
        self.run_cmd('git pull')
        self.run_cmd('{} -m pip install -r ../requirements.txt'.format(sys.executable))
        self.run_cmd('{} manage.py test --tag=front --settings disclosures.settings.prod declarations/tests  --no-input'.format(
            sys.executable
        ))

        self.logger.info("all done")


if __name__ == '__main__':
    TUpdater().main()