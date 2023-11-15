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
            //AllPrimes();
            //Sieve();
            //GuessingGame();
            //LeapYears();
            AlternatingSeries();
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
            BigInteger p = 2;
            do
            {
                bool composite = false;

                for (BigInteger i = p - 1; i > 1; i -= 1)
                {
                    if (i != 1 && p % i == 0)
                    {
                        composite = true;
                        break;
                    }
                }

                if (!composite)
                {
                    Console.Write($"{p} ");
                }                
                
                p += 1;
            }
            while(1 == 1);
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

        /// <summary>
        /// Write a guessing game where the user has to guess a secret number. After every guess
        /// the program tells the user whether their number was too large or too small. At the end
        /// the number of tries needed should be printed. It counts only as one try if they input
        /// the same number multiple times consecutively.
        /// </summary>
        private static void GuessingGame()
        {
            const int limit = 100;
            var secretNumber = new Random().Next(limit);
            int numTries = 0;
            var guesses = new List<int>();
            bool correct = false;
            
            while (!correct)
            {
                Console.Write("Guess the secret number: ");
                int.TryParse(Console.ReadLine(), out var currentGuess);
                
                if (guesses.Contains(currentGuess))
                {
                    Console.WriteLine($"Already guessed {currentGuess}");
                    continue;
                }
                
                guesses.Add(currentGuess);
                numTries += 1;

                if (currentGuess == secretNumber)
                {
                    correct = true;
                    Console.WriteLine($"Correct! The secret number was {secretNumber}!");
                }
                else if (currentGuess < secretNumber)
                {
                    Console.WriteLine("Your guess is less than the secret number!");
                }
                else if (currentGuess > secretNumber)
                {
                    Console.WriteLine("Your guess is greater than the secret number!");
                }

                Console.WriteLine($"{numTries} guesses");
            }
        }

        /// <summary>
        /// Write a program that prints the next 20 leap years.
        /// </summary>
        private static void LeapYears()
        {
            var currentYear = DateTime.Now.Year;
            var foundLeapYears = new List<int>();
            
            var checkYear = currentYear;

            do
            {
                if (checkYear % 4 == 0 && (checkYear % 100 != 0 || checkYear % 400 == 0))
                {
                    foundLeapYears.Add(checkYear);
                }

                checkYear += 1;
            }
            while (foundLeapYears.Count < 20);

            Console.WriteLine("Next 20 leap years:");
            
            foreach (int year in foundLeapYears)
            {
                Console.Write($"{year} ");
            }
        }

        /// <summary>
        /// Write a program that computes the sum of an alternating series where each element
        /// of the series is an expression of the form ((-1)^(k+1))/(2*k-1) for each value of k
        /// from 1 to 1000000, multiplied by 4.
        /// </summary>
        private static void AlternatingSeries()
        {
            double runningSum = 0;

            for (int k = 0; k < 1000000; k += 1)
            {
                runningSum += Math.Pow(-1, k + 1) / (2 * k - 1);
            }

            runningSum *= 4;

            Console.WriteLine(runningSum);
        }
    }
}