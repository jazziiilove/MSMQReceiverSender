# MSMQReceiverSender
Simple MSMQ Sender and Receiver

You need to run the sender which will create a private queue with this qualified name, pc900\private$\queue
You would need to change this path in the code. To find out what a queue name can be, simply create a private queue in MSMQ in Computer Management of your Windows.
Then, check the name of the manually created queue and then in the same manner, you can change the name of the queue in the code

Note that, "every time" you need to run the sender first and once the receiver consumes it, the queue gets empty.
