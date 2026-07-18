using Confluent.Kafka;
using System.Windows.Forms;

namespace KafkaChatWinForms
{
    public class ConsumerService
    {
        public static void StartConsumer(ListBox listBox)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = Guid.NewGuid().ToString(),   // Unique group for each app instance
                AutoOffsetReset = AutoOffsetReset.Latest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe("chat-topic");

            while (true)
            {
                var result = consumer.Consume();

                listBox.Invoke(new Action(() =>
                {
                    listBox.Items.Add("Friend: " + result.Message.Value);
                }));
            }
        }
    }
}
