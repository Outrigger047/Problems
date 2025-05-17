using System.Diagnostics;

namespace Problems
{
    public static class SortAlgorithms
    {
        /// <summary>
        /// Selection sort
        /// </summary>
        /// <param name="toSortIn">Collection of items to be sorted</param>
        /// <param name="stopwatch">Initialized <see cref="Stopwatch"/> for performance purposes</param>
        /// <returns>Sorted collection</returns>
        public static LinkedList<int> SelectionSort(ICollection<int> toSortIn, Stopwatch stopwatch)
        {
            stopwatch.Reset();
            stopwatch.Start();
            var toSort = new List<int>(toSortIn);
            var sorted = new LinkedList<int>();

            while (toSort.Count() > 0)
            {
                int lowest = toSort.First();
                foreach (var item in toSort)
                {
                    if (item <= lowest)
                    {
                        lowest = item;
                    }
                }

                sorted.Add(toSort.Where(x => x == lowest).First());
                toSort.Remove(lowest);
            }

            stopwatch.Stop();
            return sorted;
        }

        /// <summary>
        /// Insertion sort
        /// </summary>
        /// <param name="toSortIn">Collection of items to be sorted</param>
        /// <param name="stopwatch">Initialized <see cref="Stopwatch"/> for performance purposes</param>
        /// <returns>Sorted collection</returns>
        public static LinkedList<int> InsertionSort(ICollection<int> toSortIn, Stopwatch stopwatch)
        {
            stopwatch.Reset();
            stopwatch.Start();
            var toSort = new List<int>(toSortIn);
            var sorted = new LinkedList<int>();



            stopwatch.Stop();
            return sorted;
        }

        /// <summary>
        /// Merge sort
        /// </summary>
        /// <param name="toSortIn">Collection of items to be sorted</param>
        /// <param name="stopwatch">Initialized <see cref="Stopwatch"/> for performance purposes</param>
        /// <returns>Sorted collection</returns>
        public static LinkedList<int> MergeSort(ICollection<int> toSortIn, Stopwatch stopwatch)
        {
            throw new NotImplementedException();
            stopwatch.Reset();
            stopwatch.Start();
            var toSort = new List<int>(toSortIn);
            var sorted = new LinkedList<int>();

            stopwatch.Stop();
            return sorted;
        }

        /// <summary>
        /// Quicksort
        /// </summary>
        /// <param name="toSortIn">Collection of items to be sorted</param>
        /// <param name="stopwatch">Initialized <see cref="Stopwatch"/> for performance purposes</param>
        /// <returns>Sorted collection</returns>
        public static LinkedList<int> QuickSort(ICollection<int> toSortIn, Stopwatch stopwatch)
        {
            throw new NotImplementedException();
            stopwatch.Reset();
            stopwatch.Start();
            var toSort = new List<int>(toSortIn);
            var sorted = new LinkedList<int>();

            stopwatch.Stop();
            return sorted;
        }

        /// <summary>
        /// Stoogesort lol
        /// </summary>
        /// <param name="toSortIn">Collection of items to be sorted</param>
        /// <param name="stopwatch">Initialized <see cref="Stopwatch"/> for performance purposes</param>
        /// <returns>Sorted collection</returns>
        public static LinkedList<int> StoogeSort(ICollection<int> toSortIn, Stopwatch stopwatch)
        {
            throw new NotImplementedException();
            stopwatch.Reset();
            stopwatch.Start();
            var toSort = new List<int>(toSortIn);
            var sorted = new LinkedList<int>();

            stopwatch.Stop();
            return sorted;
        }
    }
}