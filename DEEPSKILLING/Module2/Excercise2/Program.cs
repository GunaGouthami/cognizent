using System;

namespace FinancialForecasting
{
    class Program
    {
        // Recursive method
        static double PredictFutureValue(double presentValue, double growthRate, int years)
        {
            // Base case
            if (years == 0)
            {
                return presentValue;
            }

            // Recursive case
            return PredictFutureValue(presentValue, growthRate, years - 1)
                   * (1 + growthRate);
        }

        static void Main(string[] args)
        {
            double presentValue = 10000; // Initial investment
            double growthRate = 0.10;    // 10% growth rate
            int years = 5;

            double futureValue =
                PredictFutureValue(presentValue, growthRate, years);

            Console.WriteLine("Present Value: ₹" + presentValue);
            Console.WriteLine("Growth Rate: " + (growthRate * 100) + "%");
            Console.WriteLine("Years: " + years);
            Console.WriteLine("Predicted Future Value: ₹" +
                              futureValue.ToString("F2"));

            Console.ReadLine();
        }
    }
}