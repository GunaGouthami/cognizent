namespace KafkaChatApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Kafka Chat Application =====");
            Console.WriteLine("1. Producer");
            Console.WriteLine("2. Consumer");

            Console.Write("Enter Choice : ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Producer.StartProducer();
            }
            else if (choice == 2)
            {
                Consumer.StartConsumer();
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }
        }
    }
}
