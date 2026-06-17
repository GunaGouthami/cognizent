using System;

namespace EcommerceSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Mobile", "Electronics"),
                new Product(103, "Headphones", "Accessories"),
                new Product(104, "Keyboard", "Accessories"),
                new Product(105, "Mouse", "Accessories")
            };

            int searchId = 104;

            Console.WriteLine("Linear Search:");
            Product result1 = SearchOperations.LinearSearch(products, searchId);

            if (result1 != null)
                Console.WriteLine(result1);
            else
                Console.WriteLine("Product not found");

            Console.WriteLine();

            Console.WriteLine("Binary Search:");
            Product result2 = SearchOperations.BinarySearch(products, searchId);

            if (result2 != null)
                Console.WriteLine(result2);
            else
                Console.WriteLine("Product not found");
        }
    }
}