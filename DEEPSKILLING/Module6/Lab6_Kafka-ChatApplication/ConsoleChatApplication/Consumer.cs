using Confluent.Kafka;

namespace KafkaChatApplication
{
    public class Consumer
    {
        public static void StartConsumer()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "chat-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer =
                new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe("chat-topic");

            Console.WriteLine("Consumer Started...\n");

            while (true)
            {
                var result = consumer.Consume();

                Console.WriteLine("Friend : " + result.Message.Value);
            }
        }
    }
}
