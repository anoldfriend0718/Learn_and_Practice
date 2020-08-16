from multiprocessing import Pool
import random,os, time
from mylogger import get_consoler_logger

logger=get_consoler_logger()
def run(name):
    logger.info(f"start to run {name!r}")
    time.sleep(random.randint(1,3))
    logger.info(f"complete runing {name!r} ")
    
if __name__ == "__main__":
    logger.info("start process pool")
    with Pool(4) as proc_pool:
        proc_pool.map(run,range(5))
    logger.info("all jobs done")

