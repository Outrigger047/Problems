using System.Collections;
using System.Text;

namespace Problems
{
    /// <summary>
    /// Custom singly-linked list
    /// </summary>
    /// <typeparam name="T">Type to store in the list</typeparam>
    public class LinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// First node in the list
        /// </summary>
        private Node<T>? _head;
        /// <summary>
        /// Number of elements currently in the list
        /// </summary>
        private int _count;

        /// <summary>
        /// Empty default ctor mainly for collection initialization
        /// </summary>
        public LinkedList() { }

        /// <summary>
        /// Instantiates a <see cref="LinkedList{T}"/> with a single item
        /// </summary>
        /// <param name="initialItem">Item for the list</param>
        public LinkedList(T initialItem)
        {
            _head = new Node<T> { Item = initialItem };
            _count = 1;
        }

        /// <summary>
        /// Instantiates a <see cref="LinkedList{T}"/> with a collection of items
        /// </summary>
        /// <param name="initialCollection">Collection of items for the list</param>
        public LinkedList(ICollection<T> initialCollection)
        {
            _head = new Node<T> { Item = initialCollection.First() };
            _count += 1;

            foreach (var item in initialCollection.Skip(1))
            {
                Add(item);
            }
        }

        /// <summary>
        /// Number of elements in the list
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// First node in the list
        /// </summary>
        public Node<T> Head => _head!;

        /// <summary>
        /// Indexer declaration
        /// </summary>
        /// <param name="index">Index value</param>
        /// <returns>List item at specified index</returns>
        public T this[int index] => TraverseToIndex(_head!, index).Item;

        /// <summary>
        /// Insert a new item at the end of the list
        /// </summary>
        /// <param name="itemToAdd">Item to add</param>
        public void Add(T itemToAdd)
        {
            if (_head is not null)
            {
                TraverseToEnd(_head).Next = new Node<T> { Item = itemToAdd };
            }
            else
            {
                _head = new Node<T> { Item = itemToAdd };
            }

            _count += 1;
        }

        /// <summary>
        /// Insert multiple items at the end of the list
        /// </summary>
        /// <param name="itemsToAdd">Collection of items to add</param>
        public void Add(ICollection<T> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Insert an item at a specific location in the list
        /// </summary>
        /// <param name="itemToAdd">Item to add</param>
        /// <param name="targetIndex">Location in the list to insert the item</param>
        public void InsertAt(T itemToAdd, int targetIndex)
        {
            var before = TraverseToIndex(Head, targetIndex - 1);
            var after = before.Next;
            before.Next = new Node<T> { Item = itemToAdd, Next = after };
        }

        /// <summary>
        /// Insert a collection of items at a specific location in the list
        /// </summary>
        /// <param name="itemsToAdd">Collection of items to add</param>
        /// <param name="targetIndex">Location in the list to insert the items</param>
        public void InsertAt(ICollection<T> itemsToAdd, int targetIndex)
        {
            int offset = 0;
            foreach (var item in itemsToAdd)
            {
                InsertAt(item, targetIndex + offset);
                offset += 1;
            }
        }

        /// <summary>
        /// Rotates the list by the specified number of elements
        /// </summary>
        /// <param name="k">Number of elements to rotate</param>
        public void RotateK(int k)
        {
            TraverseToEnd(Head).Next = _head;
            var newHead = TraverseToIndex(Head, k);
            TraverseToIndex(Head, k - 1).Next = null;
            _head = newHead;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this)
            {
                sb.Append($"{item?.ToString()} " ?? string.Empty);
            }

            return sb.ToString();
        }

        /// <summary>
        /// ToString override with additional verbosity option
        /// </summary>
        /// <param name="verbose">Prints element count and type if true</param>
        /// <returns>List contents as a string</returns>
        public string ToString(bool verbose = false)
        {
            if (verbose)
            {
                return $"List contents ({_count} {typeof(T).Name}): " + ToString();
            }
            else
            {
                return ToString();
            }
        }

        /// <summary>
        /// Traverses the list and returns the final element
        /// </summary>
        /// <remarks>Recursive implementation</remarks>
        /// <param name="start">Start node</param>
        /// <returns>Final element in the list</returns>
        private Node<T> TraverseToEnd(Node<T> start)
        {
            if (start.Next is null)
            {
                return start;
            }
            else
            {
                return TraverseToEnd(start.Next);
            }
        }

        /// <summary>
        /// Traverses the list and returns a specific element
        /// </summary>
        /// <remarks>Recursive implementation</remarks>
        /// <param name="start">Start node</param>
        /// <param name="targetIndex">Node to retrieve</param>
        /// <returns>Specified node in the list</returns>
        /// <exception cref="ArgumentException">Direct invocation without start node at list head could overrun list bounds</exception>
        /// <exception cref="IndexOutOfRangeException">Inde value beyond range of list size</exception>
        private Node<T> TraverseToIndex(Node<T> start, int targetIndex, int i = 0)
        {
            // Prevent initial invocation with a custom start location that could overrun list bounds
            if (start != _head && i == 0)
            {
                throw new ArgumentException("Direct invocation without start node at list head could overrun list bounds.");
            }

            if (targetIndex <= _count - 1)
            {
                if (start.Next is null || targetIndex == 0 || i == targetIndex)
                {
                    return start;
                }
                else
                {
                    return TraverseToIndex(start.Next, targetIndex, i += 1);
                }
            }
            else
            {
                throw new IndexOutOfRangeException($"Index value {targetIndex} beyond range of list size {_count}");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LLEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LLEnumerator(this);
        }

        /// <summary>
        /// Enumerator implementation for <see cref="LinkedList{T}"/>
        /// </summary>
        public class LLEnumerator : IEnumerator<T>
        {
            private LinkedList<T> _list;
            private Node<T> _currentNode;
            private Node<T> _initNode;
            private bool disposedValue;

            object IEnumerator.Current => _currentNode.Item!;

            public T Current => _currentNode.Item;

            public LLEnumerator(LinkedList<T> list)
            {
                _list = list;
                _initNode = new() { Item = default!, Next = _list.Head };
                _currentNode = _initNode;
            }

            public bool MoveNext()
            {
                if (_currentNode.Next is not null)
                {
                    _currentNode = _currentNode.Next;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                _currentNode = _initNode;
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects)
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                    // TODO: set large fields to null
                    disposedValue = true;
                }
            }

            public void Dispose()
            {
                // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// List node
        /// </summary>
        /// <typeparam name="T"/>
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        public class Node<T>
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
        {
            /// <summary>
            /// List item
            /// </summary>
            public required T Item { get; set; }
            /// <summary>
            /// Next node in the list
            /// </summary>
            public Node<T>? Next { get; set; }
        }
    }
}