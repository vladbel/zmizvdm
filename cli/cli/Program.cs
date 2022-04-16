using System;

namespace cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("zmizvdm CLI ...");

            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    // process command
                    Console.WriteLine($"command handled: {input}");
                }
            }

            
        }
    }
}
