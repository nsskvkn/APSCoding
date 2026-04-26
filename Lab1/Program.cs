using System;
using Lab1;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose demo:");
            Console.WriteLine("1 - Simple Demo");
            Console.WriteLine("2 - Interactive Demo");

            var input = Console.ReadLine();

            if (input == "1")
            {
                Demo1.Run();
            }
            else if (input == "2")
            {
                Demo2.Run();
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
    }
}
