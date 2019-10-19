using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._6.Списък_методи_допълнително_упражнения._01
{
    public class DoublyLinkedList<T>: IEnumerable<T>
    {
        private class ListNode<T>
        {
            public T Value { get; private set; }
            public ListNode<T> NextNode { get; set; }
            public ListNode<T> PrevNode { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
                this.PrevNode = null;
                this.NextNode = null;
            }
        }

        private ListNode<T> head;
        private ListNode<T> tail;
        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            head = tail = null;
            Count = 0;
        }

        public void AddFirst(T element)
        {
            if(this.Count == 0)
            {
                head = tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newNode = new ListNode<T>(element);
                head.PrevNode = newNode;
                newNode.NextNode = head;
                head = newNode;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                head = tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newNode = new ListNode<T>(element);
                tail.NextNode = newNode;
                newNode.PrevNode = tail;
                tail = newNode;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new System.ArgumentException("List is empty");
            }

            ListNode<T> removedNode = head;
            if (Count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.NextNode;
                head.PrevNode = null;
            }
            Count--;
            return removedNode.Value;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new System.ArgumentException("List is empty");
            }
            ListNode<T> removedNode = tail;
            if (Count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.PrevNode;
                tail.NextNode = null;
            }
            Count--;
            return removedNode.Value;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] result = new T[Count];
            int i = 0;
            ListNode<T> currentNode = head;
            while (currentNode != null)
            {
                result[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
                i++;
            }
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currentNode = head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
             }
        }

    }
}
