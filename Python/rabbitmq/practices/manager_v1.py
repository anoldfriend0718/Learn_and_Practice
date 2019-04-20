import pika
import sys
import os
sys.path.append(os.path.abspath("C:/MyRepo/Learn_and_Practice/Python/rabbitmq/practices"))
import json
import subprocess

def callback(ch, method, properties, body):
    print(" [x] %r" % body)

def manage():
    #initial rabbitmq
    connection = pika.BlockingConnection(
    pika.ConnectionParameters(host='localhost'))
    channel = connection.channel()
    exchange_name='result_output'
    queue_name='result_queue'
    channel.exchange_declare(exchange=exchange_name, 
                            exchange_type='fanout')
    channel.queue_declare(queue=queue_name,
                        exclusive=True,
                        auto_delete=True)
    channel.queue_bind(queue=queue_name,
                        exchange=exchange_name)

    print(' [*] result queue is created by manager ')
    channel.basic_consume(queue=queue_name, 
                         on_message_callback=callback, 
                         auto_ack=True)
    


    print(' [*] result queue is waiting for the message ')

    #assign tasks to workers
    tasks=['["1","2","3"]','["4","5","6"]']
    workers=[]
    for task in tasks:
        print(" Task: {0}".format(task))
        new_worker=subprocess.Popen("python worker.py {}".format(task))
        workers.append(new_worker)

    #end
    for worker in workers:
        worker.wait() 
    channel.start_consuming() #block consuming , the next line- connection close- is never implemented
    connection.close()


if __name__ == "__main__":
    manage()

