using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._8.Стек_допълнително_упражнение._01
{
    public class LinkedStack<T>
    {
        private class Node<T>
        {
            private T value;
            public T Value { get => value; }
            public Node<T> NextNode { get; set; }
            public Node(T value, Node<T> nextNode = null)
            {
                this.value = value;
                this.NextNode = nextNode;
            }
        }

        private Node<T> firstNode;
        public int Count { get; private set; }

        public LinkedStack()
        {
            this.firstNode = null;
            this.Count = 0;
        }

        public void Push(T element)
        {
            this.firstNode = new Node<T>(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new System.InvalidOperationException("Stack is empty :-(");
            T element = firstNode.Value;
            firstNode = firstNode.NextNode;
            Count--;
            return element;
        }

        public T[] ToArray()
        {
            T[] result = new T[Count];
            Node<T> current = firstNode;
            for (int i = 0; i < Count; i++)
            {
                result[i] = current.Value;
                current = current.NextNode;
            }
            return result;
        }
    }

}
