using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

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
            var numbers = ListHelpers.GetNumsCollectionRandom(30, 100);

            // Storage for value being replaced
            int swapSpot;

            int lowIndex = 0;
            int highIndex = numbers.Count - 1;

            while (lowIndex < highIndex)
            {
                swapSpot = numbers[highIndex];
                numbers[highIndex] = numbers[lowIndex];
                numbers[lowIndex] = swapSpot;

                lowIndex += 1;
                highIndex -= 1;
            }

            Console.Write($"Reversed: ");
            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Write a function that checks whether an element occurs in a list.
        /// </summary>
        private static void FindElement()
        {
            var numbers = ListHelpers.GetNumsCollectionRandom(20, 100);

            Console.Write("Enter number to find: ");
            int.TryParse(Console.ReadLine(), out var numToFind);

            bool found = false;
            int foundIndex = -1;
            for (int i = 0; i < numbers.Count; i += 1)
            {
                if (numbers[i] == numToFind)
                {
                    found = true;
                    foundIndex = i;
                    break;
                }
            }

            // Kind of ugly string interpolation...
            Console.WriteLine($"Element '{numToFind}' {(found ? "found" : "not found")} {(found ? "at index" : "")} {(found ? foundIndex : "")}");
        }

        /// <summary>
        /// Write a function that returns the elements on odd positions in a list.
        /// </summary>
        private static void OddElements()
        {
            var numbers = ListHelpers.GetNumsCollectionRandom(20, 100);

            Console.Write("Odd-Indexed Elements: ");
            for (int i = 0; i < numbers.Count; i += 1)
            {
                if (i % 2 != 0)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
        }

        /// <summary>
        /// Write a function that computes the running total of a list.
        /// </summary>
        private static void RunningTotal()
        {
            var numbers = ListHelpers.GetNumsCollectionRandom(20, 100);

            int runningTotal = 0;
            foreach (var number in numbers)
            {
                runningTotal += number;
            }

            Console.WriteLine($"Total: {runningTotal}");
        }

        /// <summary>
        /// Write a function that tests whether a string is a palindrome.
        /// </summary>
        private static void Palindrome()
        {
            Console.Write("Enter string: ");
            var input = Console.ReadLine();
            var inputChars = input?.ToLower().Replace(" ", string.Empty).ToCharArray() ?? string.Empty.ToCharArray();

            bool isPalindrome = true;
            for (int i = 0; i < inputChars.Length / 2; i += 1)
            {
                if (inputChars[i] != inputChars[inputChars.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            Console.WriteLine($"'{input}' {(isPalindrome ? "is" : "is not")} a palindrome");
        }

        /*
        * Write three functions that compute the sum of the numbers in a list: using a for-loop,
        * a while-loop and recursion. (Subject to availability of these constructs in your language
        * of choice.)
        *
        * My note: I already did for-loop total in RunningTotal, so I will do while-loop and recursion
        * below.
        */

        /// <summary>
        /// While-loop sum of numbers in a list.
        /// </summary>
        private static void WhileSums()
        {
            var numbers = ListHelpers.GetNumsCollectionRandom(20, 100);

            int runningTotal = 0;
            int i = 0;
            while (i < numbers.Count)
            {
                runningTotal += numbers[i];
                i += 1;
            }

            Console.WriteLine($"Total: {runningTotal}");
        }

        /// <summary>
        /// Recursion sums of numbers in a list.
        /// </summary>
        /// <remarks>
        /// Recursion is in external helper method <see cref="ListHelpers.AddNums(List{int})"/>.
        /// </remarks>
        private static void RecursionSums()
        {
            var numbers = ListHelpers.GetNumsCollectionRandom(20, 100);
            var sum = ListHelpers.AddNums(numbers);
            Console.WriteLine($"Sum: {sum}");
        }

        /// <summary>
        /// Write a function on_all that applies a function to every element of a list. Use it to print
        /// the first twenty perfect squares. The perfect squares can be found by multiplying each natural
        /// number with itself. The first few perfect squares are 1*1= 1, 2*2=4, 3*3=9, 4*4=16. Twelve for
        /// example is not a perfect square because there is no natural number m so that m*m=12. (This
        /// question is tricky if your programming language makes it difficult to pass functions as 
        /// arguments.)
        /// </summary>
        private static void PerfectSquares()
        {
            var firstTwenty = new List<int>();
            for (int i = 1; i <= 20; i += 1)
            {
                firstTwenty.Add(i);
            }

            Console.Write("First 20 perfect squares: ");
            ListHelpers.OnAll(firstTwenty, ListHelpers.PrintSquare);
        }

        /// <summary>
        /// Write a function that concatenates two lists. [a,b,c], [1,2,3] -> [a,b,c,1,2,3]
        /// </summary>
        private static void CatList()
        {
            var firstList = ListHelpers.GetNumsCollectionRandom(5, 100);
            var secondList = ListHelpers.GetNumsCollectionRandom(5, 100);

            var combinedList = new List<int>();
            foreach (var number in firstList)
            {
                combinedList.Add(number);
            }

            foreach (var number in secondList)
            {
                combinedList.Add(number);
            }

            Console.Write("Combined list: ");
            foreach (var number in combinedList)
            {
                Console.Write($"{number} ");
            }
        }

        /// <summary>
        /// Write a function that combines two lists by alternatingly taking elements, e.g. [a,b,c], 
        /// [1,2,3] -> [a,1,b,2,c,3].
        /// </summary>
        private static void CatListAlternate()
        {
            var firstList = ListHelpers.GetNumsCollectionRandom(10, 100);
            var secondList = ListHelpers.GetNumsCollectionRandom(15, 100);

            var combinedList = new List<int>();

            while (firstList.Any() || secondList.Any())
            {
                if (firstList.Any())
                {
                    combinedList.Add(firstList.First());
                    firstList.RemoveAt(0);
                }

                if (secondList.Any())
                {
                    combinedList.Add(secondList.First());
                    secondList.RemoveAt(0);
                }
            }

            Console.Write("Combined list: ");
            foreach (var number in combinedList)
            {
                Console.Write($"{number} ");
            }
        }

        /// <summary>
        /// Write a function that merges two sorted lists into a new sorted list. [1,4,6],[2,3,5] -> 
        /// [1,2,3,4,5,6]. You can do this quicker than concatenating them followed by a sort.
        /// </summary>
        private static void MergeSorted()
        {
            var firstList = ListHelpers.GetNumsCollectionRandom(10, 100, sort: true);
            var secondList = ListHelpers.GetNumsCollectionRandom(35, 100, sort: true);

            var combinedList = new List<int>();

            while (firstList.Any() && secondList.Any())
            {
                if (firstList[0] < secondList[0])
                {
                    combinedList.Add(firstList.First());
                    firstList.RemoveAt(0);
                }
                else
                {
                    combinedList.Add(secondList.First());
                    secondList.RemoveAt(0);
                }
            }

            while (firstList.Any())
            {
                combinedList.Add(firstList.First());
                firstList.RemoveAt(0);
            }

            while (secondList.Any())
            {
                combinedList.Add(secondList.First());
                secondList.RemoveAt(0);
            }

            Console.Write("Combined list: ");
            foreach (var number in combinedList)
            {
                Console.Write($"{number} ");
            }
        }

        /// <summary>
        /// Write a function that rotates a list by k elements. For example [1,2,3,4,5,6] rotated by two
        /// becomes [3,4,5,6,1,2]. Try solving this without creating a copy of the list. How many swap
        /// or move operations do you need?
        /// </summary>
        /// <remarks>
        /// Soltuion is public method <see cref="LinkedList{T}.RotateK(int)"/>
        /// </remarks>
        private static void RotateK()
        {
            Console.Write("Specify k value: ");
            var k = int.Parse(Console.ReadLine()!);
            Console.Write("Specify list size: ");
            var size = int.Parse(Console.ReadLine()!);

            var ll = new LinkedList<int>(ListHelpers.GetNumsCollectionRandom(size, 100, writeConsole: false));

            Console.WriteLine(ll);

            ll.RotateK(k);

            Console.WriteLine("Rotated " + ll);
        }

        /// <summary>
        /// Write a function that computes the list of the first 100 Fibonacci numbers. The first two Fibonacci
        /// numbers are 1 and 1. The n+1-st Fibonacci number can be computed by adding the n-th and the n-1-th
        /// Fibonacci number. The first few are therefore 1, 1, 1+1=2, 1+2=3, 2+3=5, 3+5=8.
        /// </summary>
        private static void Fib100()
        {
            var fib100Arr = new Int128[100];
            fib100Arr[0] = 1;
            fib100Arr[1] = 1;

            for (int i = 2; i < 100; i += 1)
            {
                checked
                {
                    fib100Arr[i] = fib100Arr[i - 1] + fib100Arr[i - 2];
                }
            }

            foreach (var num in fib100Arr)
            {
                Console.Write($"{num} ");
            }
        }

        /// <summary>
        /// Write a function that takes a number and returns a list of its digits. So for 2342 it should return [2,3,4,2].
        /// </summary>
        private static void ListDigits()
        {
            Console.Write("Input number: ");
            var num = int.Parse(Console.ReadLine()!);
            var digits = new Stack<int>();

            do
            {
                digits.Push(num % 10);
                num = num / 10;
            }
            while (num > 10);

            digits.Push(num);

            foreach (var digit in digits)
            {
                Console.Write($"{digit} ");
            }
        }

        /*
        * Write functions that add, subtract, and multiply two numbers in their digit-list representation (and return a
        * new digit list). If you’re ambitious you can implement Karatsuba multiplication. Try different bases. What is
        * the best base if you care about speed? If you couldn’t completely solve the prime number exercise above due to
        * the lack of large numbers in your language, you can now use your own library for this task.
        */

        /*
        private static void AddDigitList()
        {

        }
        */

        /*
        private static void SubtractDigitList()
        {

        }
        */

        /*
        private static void KMultiply()
        {

        }
        */
        /*
        /// <summary>
        /// Write a function that takes a list of numbers, a starting base b1 and a target base b2 and interprets the list as
        /// a number in base b1 and converts it into a number in base b2 (in the form of a list-of-digits). So for example 
        /// [2,1,0] in base 3 gets converted to base 10 as [2,1].
        /// </summary>
        private static void BaseConversion()
        {

        }
        */

        /// <summary>
        /// Implement the following sorting algorithms: Selection sort, Insertion sort, Merge sort, Quick sort, Stooge Sort. 
        /// Check Wikipedia for descriptions.
        /// </summary>
        private static void AssortedSorts()
        {
            Console.Write("Input integers separated by spaces: ");
            var numsToSort = new List<int>();
            foreach (var num in Console.ReadLine()!.Split(' '))
            {
                numsToSort.Add(int.Parse(num));
            }

            var stopwatch = new Stopwatch();

            Console.WriteLine("Selection sort: "
                + SortAlgorithms.SelectionSort(numsToSort, stopwatch)
                + $"({stopwatch.ElapsedTicks} ticks, {stopwatch.ElapsedMilliseconds} msec)");
            Console.WriteLine("Insertion sort: "
                + SortAlgorithms.InsertionSort(numsToSort, stopwatch)
                + $"({stopwatch.ElapsedTicks} ticks, {stopwatch.ElapsedMilliseconds} msec)");
            Console.WriteLine("Merge sort: "
                + SortAlgorithms.MergeSort(numsToSort, stopwatch)
                + $"({stopwatch.ElapsedTicks} ticks, {stopwatch.ElapsedMilliseconds} msec)");
            Console.WriteLine("Quicksort: "
                + SortAlgorithms.InsertionSort(numsToSort, stopwatch)
                + $"({stopwatch.ElapsedTicks} ticks, {stopwatch.ElapsedMilliseconds} msec)");
            Console.WriteLine("Stooge sort: "
                + SortAlgorithms.InsertionSort(numsToSort, stopwatch)
                + $"({stopwatch.ElapsedTicks} ticks, {stopwatch.ElapsedMilliseconds} msec)");
        }

        /*
        /// <summary>
        /// Implement binary search.
        /// </summary>
        private static void BinarySearch()
        {

        }
        */
        /*
        /// <summary>
        /// Write a function that takes a list of strings an prints them, one per line, in a rectangular frame. For example, 
        /// the list ["Hello", "World", "in", "a", "frame"] gets printed as:
        /// 
        ///   *********
        ///   * Hello *
        ///   * World *
        ///   * in    *
        ///   * a     *
        ///   * frame *
        ///   *********
        /// 
        /// </summary>
        private static void FramedText()
        {

        }
        */
    }
}