print('__file__={0:<35} | __name__={1:<20} | __package__={2:<20}'.format(__file__,__name__,str(__package__)))
import subprocess 
import os 
import psutil
import time

from .mylogger import get_consoler_logger


logger=get_consoler_logger()
proc=subprocess.Popen("python .\multiprocess\pool.py ")
logger.info(f"start a child process to run pool program:{proc.pid}")
time.sleep(0.5)
grandchildProcess=psutil.Process(proc.pid).children(recursive=True)
logger.info(grandchildProcess)
logger.info("end")
