import pika
import sys
import os
sys.path.append(os.path.abspath("C:/MyRepo/Learn_and_Practice/Python/rabbitmq/practices"))
import json
import subprocess
from logger_thread_v2 import LoggerThread 


def manage():
    loggerthread = LoggerThread()
    loggerthread.start()
    #assign tasks to workers
    tasks=['["1","2","3"]','["4","5","6"]']
    workers=[]
    for task in tasks:
        new_worker=subprocess.Popen("python worker.py {}".format(task))
        workers.append(new_worker)

    for worker in workers:
        worker.wait() 
    loggerthread.stop()
    loggerthread.join()

if __name__ == "__main__":
    manage()