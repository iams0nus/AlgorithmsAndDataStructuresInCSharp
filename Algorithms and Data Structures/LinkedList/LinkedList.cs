using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }


        #region Add

        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> oldHead = Head;

            Head = node;

            Head.Next = oldHead;

            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;       
            }
            else
            {
                Tail.Next = node;
            }
            Tail = node;
            Count++;
        }
        #endregion

        #region Remove
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;
                if (Count == 0)
                {
                    Tail = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    LinkedListNode<T> current = Head;
                    while(current.Next != Tail)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    Tail = current;
                }
                Count--;
            }
        }
        #endregion

        #region ICollection

        public int Count { get; private set; }

        public bool IsReadOnly { get { return false; } }

        void ICollection<T>.Add(T item)
        {
            AddFirst(item);
        }

        void ICollection<T>.Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        bool ICollection<T>.Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while(current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                    
                }
                current = current.Next;
            }
            return false;
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while(current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;

            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        bool ICollection<T>.Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                    }
                    else
                    {
                        RemoveFirst();
                    }

                    return true; 
                }
                
                previous = current;
                current = current.Next;
            }
            return false;
        }
        #endregion



    }
}
