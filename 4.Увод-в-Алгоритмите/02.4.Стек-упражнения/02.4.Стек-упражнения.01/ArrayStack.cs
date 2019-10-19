using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._4.Стек_упражнения._01
{
    public class ArrayStack<T>
    {

        private T[] elements;
        public int Count { get; private set; }
        private const int InitialCapacity = 16;

        public ArrayStack(int capacity = InitialCapacity)
        {
            Count = 0;
            elements = new T[capacity];
        }

        public void Push(T element)
        {
            if (Count == elements.Length)
                Grow();
            elements[Count++] = element;
         }

        public T Pop()
        {
            if (Count == 0)
                throw new System.InvalidOperationException("Stack is empty");
            return elements[--Count];
        }

        public T[] ToArray()
        {
            T[] newElements = CopyArray(Count, Count);
            return newElements;
        }

        private T[] CopyArray(int capacity, int copyCount)
        {
            T[] newElements = new T[capacity];
            for (int i = 0; i < copyCount; i++)
            {
                newElements[i] = elements[i];
            }
            return newElements;
        }

        private void Grow()
        {
            T[] newElements = CopyArray(2 * this.elements.Length, elements.Length);
            this.elements = newElements;
        }
    }

}
