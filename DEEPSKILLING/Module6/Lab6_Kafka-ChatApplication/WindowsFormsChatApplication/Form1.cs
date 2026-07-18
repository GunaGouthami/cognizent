using Confluent.Kafka;

namespace KafkaChatWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            producer.Produce("chat-topic", new Message<Null, string>
            {
                Value = txtMessage.Text
            });

            producer.Flush(TimeSpan.FromSeconds(2));

            lstMessages.Items.Add("Me: " + txtMessage.Text);

            txtMessage.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ConsumerService.StartConsumer(lstMessages);
            });
        }
    }
}
