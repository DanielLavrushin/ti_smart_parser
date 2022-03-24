from common.logging_wrapper import setup_logging
from predict_office.tensor_flow_model import TTensorFlowOfficeModel
import argparse


def parse_args():
    parser = argparse.ArgumentParser()
    parser.add_argument("--bigrams-path", dest='bigrams_path', required=False, default="office_ngrams.txt")
    parser.add_argument("--test-pool", dest='test_pool')
    parser.add_argument("--model-folder", dest='model_folder', required=False)
    parser.add_argument("--debug-mode", dest='debug_mode', action="store_true", default=False)
    parser.add_argument("--threshold", dest='threshold', required=False, type=float, default=[0.6], nargs="*")
    return parser.parse_args()


def main():
    logger = setup_logging(log_file_name="predict_office_test.log")
    args = parse_args()
    model = TTensorFlowOfficeModel(logger, args.bigrams_path, args.model_folder,
                                   test_pool=args.test_pool, debug_mode=args.debug_mode)
    model.test_model(thresholds=args.threshold)


if __name__ == "__main__":
    main()
