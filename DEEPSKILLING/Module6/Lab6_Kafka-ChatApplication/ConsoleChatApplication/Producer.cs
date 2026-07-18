using Confluent.Kafka;

namespace KafkaChatApplication
{
    public class Producer
    {
        public static void StartProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            Console.WriteLine("Producer Started");
            Console.WriteLine("Type messages (type 'exit' to stop)\n");

            while (true)
            {
                Console.Write("You : ");
                string message = Console.ReadLine();

                if (message.ToLower() == "exit")
                    break;

                producer.Produce("chat-topic", new Message<Null, string>
                {
                    Value = message
                });

                producer.Flush(TimeSpan.FromSeconds(2));
            }
        }
    }
}
