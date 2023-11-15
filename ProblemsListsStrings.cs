namespace Problems
{
    public partial class Program
    {
        /// <summary>
        /// Write a function that returns the largest element in a list.
        /// </summary>
        private static void ListLargestElement()
        {
            Console.WriteLine("Enter 10 integers");

            var numbers = new List<int>();
            for (int i = 0; i < 10; i += 1)
            {
                Console.Write($"{i + 1}: ");
                int.TryParse(Console.ReadLine(), out var number);
                numbers.Add(number);
            }

            int runningLargest = 0;
            foreach (var number in numbers)
            {
                if (number > runningLargest)
                {
                    runningLargest = number;
                }
            }

            Console.WriteLine($"Largest number: {runningLargest}");
        }
    }
}