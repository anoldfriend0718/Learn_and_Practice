import logging
import time
import threading

def thread_function(name):
    logging.info("Entering...")
    logging.info(f"Run {name!r}")
    time.sleep(1)
    logging.info("Done...")

format = "%(asctime)s %(thread)d: %(message)s"
logging.basicConfig(format=format, level=logging.DEBUG,
                    datefmt="%H:%M:%S")
logging.info("Main    : before creating thread")
x = threading.Thread(target=thread_function, args=(1,))
logging.info("Main    : before running thread")
x.start()
logging.info("Main    : wait for the thread to finish")
x.join()
logging.info("Main    : all done")       