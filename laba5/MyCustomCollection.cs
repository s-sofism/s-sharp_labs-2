using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public class MyCustomCollection<T> : ICustomCollection<T>
    {
        private class Node
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }
        }

        Node head;
        Node tail;
        int cursor = 0;
        int count;

        public T this[int index]
        {
            get
            {
                if (index > count - 1)
                {
                    Console.WriteLine("\nbigger than amount of elements\n");
                    System.Environment.Exit(0);
                }
                if (index < 0)
                {
                    Console.WriteLine("\nbelow zero\n");
                    System.Environment.Exit(0);
                }

                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                if (index > count - 1)
                {
                    Console.WriteLine("\nbigger than amount of elements\n");
                    System.Environment.Exit(0);
                }
                if (index < 0)
                {
                    Console.WriteLine("\nbelow zero\n");
                    System.Environment.Exit(0);
                }

                Node current = head;
                for (int i = 0; i <= index; i++)
                {
                    current = current.Next;
                }
                current.Data = value;
            }
        }

        public void Reset()
        {
            cursor = 0;
        }

        public void Next()
        {
            if (cursor == count)
            {
                Console.WriteLine("\nthat was the last element\n");
                throw new ArgumentOutOfRangeException();
            }
            cursor++;
        }

        public void Previous()
        {
            if (cursor <= 0)
            {
                Console.WriteLine("\nthere no elements\n");
                throw new ArgumentOutOfRangeException();
            }
            cursor--;
        }

        public T Current()
        {
            if (cursor < 0 || cursor > count - 1)
            {
                Console.WriteLine("\ncursor is non-valid\n");
                throw new ArgumentOutOfRangeException();
            }
            Node current = head;
            for (int i = 0; i < cursor; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public void Add(T item)
        {
            Node node = new Node(item);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public void Remove(T item)
        {
            Node current = head;
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(item))
                {
                    break;
                }
                current = current.Next;
            }

            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                count--;
            }
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public T RemoveCurrent()
        {
            if (cursor < 0 || cursor > count - 1)
            {
                Console.WriteLine("\ncursor is non-valid\n");
                throw new ArgumentOutOfRangeException();
            }

            Node current = head;
            for (int i = 0; i < cursor + 1; i++)
            {
                current = current.Next;
            }

            T data = current.Data;
            Remove(data);
            return data;
        }
    }
}
