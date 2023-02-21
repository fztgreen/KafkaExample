using Confluent.Kafka;
using KafkaExample.Models;
using ProtoBuf;
using RandomTestValues;
using System;
using System.Collections;

class Program
{
    public static async Task Main(string[] args)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        // If serializers are not specified, default serializers from
        // `Confluent.Kafka.Serializers` will be automatically used where
        // available. Note: by default strings are encoded as UTF8.
        using (var p = new ProducerBuilder<Null, byte[]>(config).Build())
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    Serializer.Serialize(memoryStream, RandomValue.Object<Package>());
                    var byteArray = memoryStream.ToArray();

                    var dr = await p.ProduceAsync("test-topic", new Message<Null, byte[]> { Value = byteArray });
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }
    }
}