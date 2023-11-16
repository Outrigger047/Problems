namespace Problems
{
    public partial class Program
    {
        /// <summary>
        /// Write a function that returns the largest element in a list.
        /// </summary>
        private static void ListLargestElement()
        {
            var numbers = ListHelpers.GetNumsCollectionRandom(20, 100);

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

        /// <summary>
        /// Write function that reverses a list, preferably in place.
        /// </summary>
        private static void ReverseList()
        {
            var numbers = ListHelpers.GetNumsCollectionRandom(20, 100);

            // Storage for value being replaced
            int swapSpot;

            if (numbers.Count > 2)
            {
                for (int i = 0; i < numbers.Count / 2; i += 1)
                {
                    var distance = numbers.Count - 1 - i;
                    if (distance > 1)
                    {
                        swapSpot = numbers[numbers.Count - i - 1];
                        numbers[numbers.Count - i - 1] = numbers[i];
                        numbers[i] = swapSpot;
                    }
                }
            }
            else if (numbers.Count == 2)
            {
                swapSpot = numbers[numbers.Count - 1];
                numbers[numbers.Count - 1] = numbers[0];
                numbers[0] = swapSpot;
            }

            Console.Write($"Reversed: ");
            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
        }
    }
}