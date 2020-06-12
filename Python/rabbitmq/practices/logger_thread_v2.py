import threading
import time
import pika


class LoggerThread(threading.Thread):
    def __init__(self):
        super(LoggerThread, self).__init__()
        self._is_interrupted = False
        self.connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
        self.channel = self.connection.channel()
        self.exchange_name='result_output'
        self.queue_name='result_queue'
        self.exchange=self.channel.exchange_declare(exchange=self.exchange_name, 
                                                     exchange_type='fanout')
        self.queue=self.channel.queue_declare(queue=self.queue_name,
                                               exclusive=True,
                                               auto_delete=True)
        self.channel.queue_bind(queue=self.queue_name,
                           exchange=self.exchange_name)

    def stop(self):
        self._is_interrupted = True
    
    #用以表示线程活动的方法
    def run(self):
        # param float inactivity_timeout: if a number is given (in
        #     seconds), will cause the method to yield (None, None, None) after the
        #     given period of inactivity; this permits for pseudo-regular maintenance
        #     activities to be carried out by the user while waiting for messages
        #     to arrive. If None is given (default), then the method blocks until
        #     the next event arrives. NOTE that timing granularity is limited by
        #     the timer resolution of the underlying implementation.
        #     NEW in pika 0.10.0.

        for method, properties, body in self.channel.consume(self.queue_name,
                                                            auto_ack=False,
                                                            inactivity_timeout=1):      
            if self._is_interrupted == True:
                #recheck queue to get the current message count in the queue
                updatedqueue=self.channel.queue_declare(queue=self.queue_name,
                                                         exclusive=True,
                                                        auto_delete=True)
                message_count=updatedqueue.method.message_count
                if message_count == 0:
                    break
                else:
                    time.sleep(1)
                    continue
            if body is None:
                continue            
            print(body)
            self.channel.basic_ack(method.delivery_tag)


        self.channel.cancel()
        self.channel.close()
        self.connection.close()

class producer(object):
    def __init__(self):
        pass
    
    def send(self):
        connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
        channel = connection.channel()
        exchange_name='result_output'
        channel.exchange_declare(exchange=exchange_name, exchange_type='fanout')
        for index in range(100):
            message="This is {} message".format(index)
            channel.basic_publish(exchange=exchange_name,routing_key="",
                                  body=message)




def main():
    
    thread = LoggerThread()
    #启动线程活动
    producer().send()

    thread.start()
    
    time.sleep(2)
    # stop logging
    thread.stop()
    # 等待至线程中止
    thread.join()


if __name__ == "__main__":
    main()