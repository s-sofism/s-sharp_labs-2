using System;

namespace laba6
{
    /*
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
                    throw new IndexOutOfRangeException($"\nindex {index} is bigger than amount of elements\n");
                }
                if (index < 0)
                {
                    throw new IndexOutOfRangeException($"\nindex {index} is below zero\n");
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
                    throw new IndexOutOfRangeException($"\nindex {index} is bigger than amount of elements\n");
                }
                if (index < 0)
                {
                    throw new IndexOutOfRangeException($"\nindex {index} is below zero\n");
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
                throw new ArgumentOutOfRangeException("cursor is on null value");
            }
            cursor++;
        }

        public void Previous()
        {
            if (cursor <= 0)
            {
                throw new ArgumentOutOfRangeException("cursor is null or negative");
            }
            cursor--;
        }

        public T Current()
        {
            if (cursor < 0 || cursor > count - 1)
            {
                throw new ArgumentOutOfRangeException("cursor is non-valid");
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
            bool flag = false;
            Node current = head;
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(item))
                {
                    flag = true;
                    break;
                }
                current = current.Next;
            }

            if (current != null && flag == true)
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
            else
            {
                throw new ArgumentOutOfRangeException("there no that item");
            }
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public T RemoveCurrent()
        {
            if (cursor < 0 || cursor > count - 1)
            {
                throw new ArgumentOutOfRangeException("cursor is non-valid");
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
    */
}