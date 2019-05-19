using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._3.Опашка._01
{
    public class CircularQueue<T>
    {
        private const int DefaultCapacity = 4;
        private T[] elements;
        private int startIndex;
        private int endIndex;

        public int Count { get; private set; }
        
        public CircularQueue(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
            this.startIndex = 0;
            this.endIndex = 0;
        }

        public void Enqueue(T element)
        {
            if(Count >= elements.Length)
            {
                Grow();
            }
            elements[endIndex] = element;
            endIndex = (endIndex + 1) % elements.Length;
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("The queue is empty!");
            var result = elements[startIndex];
            startIndex = (startIndex + 1) % elements.Length;
            Count--;
            return result;
        }

        private void Grow()
        {
            var newElements = new T[2 * elements.Length];
            CopyAllElementsTo(newElements);
            elements = newElements;
            startIndex = 0;
            endIndex = Count;
        }

        private void CopyAllElementsTo(T[] resultArr)
        {
            int sourceIndex = this.startIndex;
            for (int destinationIndex = 0; destinationIndex < Count; destinationIndex++)
            {
                resultArr[destinationIndex] = elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % elements.Length;
            }
        }

        public T[] ToArray()
        {
            var resultArr = new T[Count];
            CopyAllElementsTo(resultArr);
            return resultArr;
        }
    }
}
