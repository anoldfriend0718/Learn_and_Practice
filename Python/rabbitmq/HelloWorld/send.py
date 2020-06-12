import pika
#We're connected now, to a broker on the local machine - hence the localhost. If we wanted to connect to a broker on a different machine we'd simply specify its name or IP address here.
connection=pika.BlockingConnection(pika.ConnectionParameters("localhost"))
channel=connection.channel()
#
channel.queue_declare(queue="hello")
#At this point we're ready to send a message. Our first message will just contain a string Hello World! and we want to send it to our hello queue.
#In RabbitMQ a message can never be sent directly to the queue, it always needs to go through an exchange. 
#All we need to know now is how to use a default exchange identified by an empty string. 
#The queue name needs to be specified in the routing_key parameter
channel.basic_publish(exchange="",
                     routing_key="hello",
                    body="Hello World!")
print(" [x] Sent 'Hello World'")
#Before exiting the program we need to make sure the network buffers were flushed and our message was actually delivered to RabbitMQ. We can do it by gently closing the connection.
connection.close()
