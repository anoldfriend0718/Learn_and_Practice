import logging

def get_consoler_logger():
    logger=logging.getLogger()
    logger.setLevel(logging.DEBUG)
    consoleHandler=logging.StreamHandler()
    formatter = logging.Formatter("[%(asctime)s] [%(levelname)s] [pid:%(process)d] %(message)s ")
    consoleHandler.setFormatter(formatter)
    consoleHandler.setLevel(logging.DEBUG)
    logger.addHandler(consoleHandler)
    return logger