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
            //MultTables();
            Sieve();
        }

        /// <summary>
        /// Write a program that prints ‘Hello World’ to the screen.
        /// </summary>
        private static void HelloWorld()
        {
            Console.WriteLine("sup world");
        }

        /// <summary>
        /// Write a program that asks the user for their name and greets them with their name.
        /// Modify the previous program such that only the users Alice and Bob are greeted with their names.
        /// </summary>
        private static void Name()
        {
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();

            if (name == "Alice" || name == "Bob")
            {
                Console.WriteLine($"Hello, {name}!");
            }
        }

        /// <summary>
        /// Write a program that asks the user for a number n and prints the sum of the numbers 1 to n
        /// </summary>
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

        /// <summary>
        /// Modify the previous program such that only multiples of three or five are considered in the sum, 
        /// e.g. 3, 5, 6, 9, 10, 12, 15 for n=17
        /// </summary>
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

        /// <summary>
        /// Write a program that asks the user for a number n and gives them the possibility to choose between
        /// computing the sum and computing the product of 1,…,n.
        /// </summary>
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

        /// <summary>
        /// Write a program that prints a multiplication table for numbers up to 12.
        /// </summary>
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

        /// <summary>
        /// Write a program that prints all prime numbers. (Note: if your programming language does not
        /// support arbitrary size numbers, printing all primes up to the largest number you can easily
        /// represent is fine too.)
        /// </summary>
        private static void AllPrimes()
        {
            
        }

        /// <summary>
        /// Sieve of Eratosthenes
        /// 
        /// NOT in the list, but trying out a way to generate primes up to a given limit.
        /// </summary>
        private static void Sieve()
        {
            Console.Write("Enter limit: ");
            int.TryParse(Console.ReadLine(), out var limit);

            // Iteratively build a collection of composite numbers
            // Given a limit n and an integer p starting with 2, mark all multiples of p up to n
            var composites = new bool[limit + 1];

            // Outer loop is our list of integers p (starting at 2) through limit n
            for (int i = 2; i < limit; i++)
            {
                // Inner loop is multiples of p
                for (int j = 2; i * j <= limit; j++)
                {
                    composites[i * j] = true; 
                }
            }

            for (int i = 2; i < limit; i++)
            {
                if (!composites[i])
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}