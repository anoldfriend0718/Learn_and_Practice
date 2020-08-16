from multiprocessing import Process
import os
from mylogger import get_consoler_logger

logger=get_consoler_logger()

def run(name):
    logger.info(f" Run {name!r}")
    logger.info(f" my parent pid is {os.getppid()}")

if __name__ == "__main__":
    logger.info(f" parent process start")
    p=Process(target=run,args=("child",),daemon=False)
    logger.info(f" child process will start")
    p.start()
    p.join()
    logger.info(f" child process end")

