import threading
import time
import pika


class WorkerThread(threading.Thread):
    def __init__(self):
        super(WorkerThread, self).__init__()
        self._is_interrupted = False

    def stop(self):
        self._is_interrupted = True
    
    #用以表示线程活动的方法
    def run(self):
        connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
        channel = connection.channel()
        channel.queue_declare("queue")
        # param float inactivity_timeout: if a number is given (in
        #     seconds), will cause the method to yield (None, None, None) after the
        #     given period of inactivity; this permits for pseudo-regular maintenance
        #     activities to be carried out by the user while waiting for messages
        #     to arrive. If None is given (default), then the method blocks until
        #     the next event arrives. NOTE that timing granularity is limited by
        #     the timer resolution of the underlying implementation.
        #     NEW in pika 0.10.0.
        for method, properties, body in channel.consume("queue",inactivity_timeout=1):
            if self._is_interrupted == True:
                break
            if body is None:
                continue            
            print(body)
            channel.basic_ack(method.delivery_tag)
        channel.cancel()
        channel.close()
        connection.close()

class producer(object):
    def __init__(self):
        pass
    
    def send(self):
        connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
        channel = connection.channel()
        channel.queue_declare(queue="queue")
        for index in range(10):
            message="This is {} message".format(index)
            channel.basic_publish(exchange="",routing_key="queue",
                                              body=message)




def main():
    thread = WorkerThread()
    #启动线程活动
    thread.start()
    producer().send()
    time.sleep(2)
    thread.stop()
    # 等待至线程中止
    thread.join()


if __name__ == "__main__":
    main()