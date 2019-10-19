using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._7.Опашка_допълнително_упражнения._01
{
    public class LinkedQueue<T>
    {
        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }

            public QueueNode(T value)
            {
                this.Value = value;
                this.PrevNode = null;
                this.NextNode = null;
            }
        }

        private QueueNode<T> head;
        private QueueNode<T> tail;
        public int Count { get; private set; }

        public LinkedQueue()
        {
            head = tail = null;
            Count = 0;
        }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                head = tail = new QueueNode<T>(element);
            }
            else
            {
                QueueNode<T> newNode = new QueueNode<T>(element);
                tail.NextNode = newNode;
                newNode.PrevNode = tail;
                tail = newNode;
            }
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new System.InvalidOperationException("Queue is empty");
            }

            QueueNode<T> removedNode = head;
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

        public T[] ToArray()
        {
            T[] result = new T[Count];
            int i = 0;
            QueueNode<T> currentNode = head;
            while (currentNode != null)
            {
                result[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
                i++;
            }
            return result;
        }

    }
}
