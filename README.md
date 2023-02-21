# Kafka Example

## Steps to Run
1. Install Dotnet & docker cli
2. Run `docker-compose up` on repo root directory
3. Run `docker exec -it broker`
4. Run `kafka-topics --bootstrap-server localhost:9092 --create --topic test-topic`
5. Exit out of Bash (`ctrl + d` should work)
6. I recommend opening 2 windows
7. run `cd KafkaExample.Consumer` and `dotnet run`
8. run `cd KafkaExample.Producer` and `dotnet run` as many times as you want
9. Observe messages sent to the Consumer

## Explanation
After the docker containers are spun up for the Kafka Broker and Zookeeper, you are ready to produce and consume messages on using Kafka.

We create the topic by gaining execution inside the broker docker container and create the topic `test-topic`

Then, we can run the Consumer and Producer to watch messages produce and consume.