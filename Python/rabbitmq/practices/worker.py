import pika
import time 
import sys
import json


def working(jobs):
    #initial 
    connection = pika.BlockingConnection(
        pika.ConnectionParameters(host='localhost'))
    channel = connection.channel()
    exchange_name='result_output'
    channel.exchange_declare(exchange=exchange_name, exchange_type='fanout')
    # print(' [*] result exchanger is created by worker ')
    # #Run computations
    # print(' [*] start computations ') 
    for job in jobs:
        time.sleep(0.1)
        result_message="result is {0}".format(job)
        #print(" [*] Output: {}".format(result_message))
        channel.basic_publish(exchange=exchange_name,
                              routing_key="",
                              body=result_message)
    # print(' [*] Done computations ')
    # print(' [*] This worker quites ')


if __name__ == "__main__":
    input=sys.argv[1:]
    print(" [*] Worker Input: {}".format(input[0]))
    jobs=json.loads(input[0])
    working(jobs)


