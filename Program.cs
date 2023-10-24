using System.Numerics;

namespace Problems
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //HelloWorld();
            //Name();
            //Sums();
            //Sums35();
            //SumOrProduct();
            MultTables();
        }

        private static void HelloWorld()
        {
            Console.WriteLine("sup world");
        }

        private static void Name()
        {
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();

            if (name == "Alice" || name == "Bob")
            {
                Console.WriteLine($"Hello, {name}!");
            }
        }

        private static void Sums()
        {
            Console.Write("Enter number: ");
            int.TryParse(Console.ReadLine(), out var num);

            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                sum = sum + i;
            }

            Console.WriteLine($"Sum: {sum}");
        }

        private static void Sums35()
        {
            Console.Write("Enter number: ");
            int.TryParse(Console.ReadLine(), out var num);

            int sum = 0;
            int[] modn = { 3, 5 };
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < modn.Length; j++)
                {
                    if (i % modn[j] == 0)
                    {
                        sum = sum + i;
                        break;
                    }
                }
            }

            Console.WriteLine($"Sum: {sum}");
        }

        private static void SumOrProduct()
        {
            Console.Write("Enter number: ");
            int.TryParse(Console.ReadLine(), out var num);
            Console.Write("Enter mode (p = product, s = sum): ");
            var mode = Console.ReadLine();

            int running = 1;
            if (mode == "p" || mode == "s")
            {
                for (int i = 1; i < num; i++)
                {
                    if (mode == "p")
                    {
                        running = running * i;
                    }
                    else if (mode == "s")
                    {
                        running = running + i;
                    }
                }

                Console.WriteLine($"{(mode == "p" ? "Product" : "Sum")}: {running}");
            }
        }

        private static void MultTables()
        {
            Console.Write("Enter limit: ");
            int.TryParse(Console.ReadLine(), out var limit);

            Console.WriteLine();
            for (int i = 1; i <= limit; i++)
            {
                Console.Write(" ");

                for (int j = 1; j <= limit; j++)
                {
                    var product = (i * j).ToString();
                    Console.Write(product);
                    
                    int whitespace;
                    if (product.Length == 1)
                    {
                        whitespace = 3;
                    }
                    else if (product.Length == 2)
                    {
                        whitespace = 2;
                    }
                    else
                    {
                        whitespace = 1;
                    }
                    
                    Console.CursorLeft = Console.CursorLeft + whitespace;
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void AllPrimes()
        {
            Console.Write("Enter limit: ");
            int.TryParse(Console.ReadLine(), out var limit);

            // Sieve of Eratosthenes

            // Build collection of composites
            
        }
    }
}