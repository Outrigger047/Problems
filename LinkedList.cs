using System.Linq;

namespace Problems
{
    public class LinkedList<T>
    {
        private Node<T> _head;
        private int _count;

        public LinkedList(T initialItem)
        {
            _head = new Node<T> { Item = initialItem };
            _count = 1;
        }

        public LinkedList(ICollection<T> initialCollection)
        {
            _head = new Node<T> { Item = initialCollection.First() };
            _count += 1;

            foreach (var item in initialCollection.Skip(1))
            {
                AddItem(item);
            }
        }

        public void AddItem(T itemToAdd)
        {
            TraverseToEnd(_head).Next = new Node<T> { Item = itemToAdd };
            _count += 1;
        }

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

        private class Node<T>
        {
            public required T Item { get; set; }
            public Node<T>? Next { get; set; }
        }
    }
}