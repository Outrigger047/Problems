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
    }
}