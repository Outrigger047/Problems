namespace Problems
{
    /// <summary>
    /// Static helper methods to reduce code redundancy
    /// </summary>
    public static class ListHelpers
    {
        /// <summary>
        /// Gets a number of integer values from the user via the console
        /// </summary>
        /// <param name="collectionCount">Number of inputs to get</param>
        /// <returns>List of user-provided integer values</returns>
        public static List<int> GetNumsCollectionConsole(int collectionCount)
        {
            var numbers = new List<int>();

            Console.WriteLine($"Enter {collectionCount} integers");

            for (int i = 0; i < collectionCount; i += 1)
            {
                Console.Write($"{i + 1}: ");
                int.TryParse(Console.ReadLine(), out var number);
                numbers.Add(number);
            }

            return numbers;
        }

        /// <summary>
        /// Gets a number of integer values from the RNG
        /// </summary>
        /// <param name="collectionCount">Number of integers to generate</param>
        /// <param name="maxValue">Max value of each integer</param>
        /// <returns>List of RNG-provided integer values</returns>
        public static List<int> GetNumsCollectionRandom(int collectionCount, int maxValue, bool writeConsole = true)
        {
            var numbers = new List<int>();
            var rng = new Random();

            for (int i = 0; i < collectionCount; i += 1)
            {
                numbers.Add(rng.Next(maxValue));
            }

            if (writeConsole)
            {
                Console.Write("Collection: ");

                foreach (var number in numbers)
                {
                    Console.Write($"{number} ");
                }

                Console.WriteLine();
            }

            return numbers;
        }

        /// <summary>
        /// Recursively calculates total sum of a list of numbers
        /// </summary>
        /// <param name="numbers">List of numbers to add</param>
        /// <returns>Total sum of all the numbers in the list</returns>
        public static int AddNums(List<int> numbers)
        {
            if (numbers.Count > 0)
            {
                int first = numbers[0];
                numbers.RemoveAt(0);
                return first + AddNums(numbers);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Applies a function to every element in a list
        /// </summary>
        /// <param name="numbers">Collection of numbers</param>
        /// <param name="function">Function to apply to every number</param>
        public static void OnAll(List<int> numbers, Action<int> function)
        {
            foreach (var number in numbers)
            {
                function(number);
            }
        }

        /// <summary>
        /// Prints the square of a number
        /// </summary>
        /// <param name="num">Number to square</param>
        /// <returns>Number multiplied by itself</returns>
        public static void PrintSquare(int num)
        {
            Console.Write($"{num * num} ");
        }
    }
}