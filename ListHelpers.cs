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
        /// <param name="numInputs">Number of inputs to get</param>
        /// <returns>List of user-provided integer values</returns>
        public static List<int> GetNumsCollectionConsole(int numInputs)
        {
            Console.WriteLine($"Enter {numInputs} integers");

            var numbers = new List<int>();
            for (int i = 0; i < numInputs; i += 1)
            {
                Console.Write($"{i + 1}: ");
                int.TryParse(Console.ReadLine(), out var number);
                numbers.Add(number);
            }

            return numbers;
        }
    }
}