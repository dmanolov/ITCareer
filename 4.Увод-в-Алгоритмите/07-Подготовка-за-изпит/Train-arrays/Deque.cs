using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class Deque<T> where T: Train
    {
        private T[] frontBuffer;
        private T[] backBuffer;
        private T[] history;

        // пазим историята тук, за да се актуализира автоматично като замине влак
        public string[] History
        {
            get
            {
                string[] result = new string[HistoryCount];
                int j = 0;
                // прочитаме всички заминали влакове в обратен ред
                for (int i = HistoryCount-1; i >= 0; i--)
                {
                    result[j] = this.history[i].ToString();
                    j++;
                }
                return result;
            }
        }
        public int BackCount { get; private set; }
        public int FrontCount { get; private set; }
        // историята е стек, направен чрез масив, както и двата края на опашката
        public int HistoryCount { get; private set; }
        public int Count
        {
            get
            {
                return BackCount + FrontCount;
            }
        }
        // казано е в условието, че влаковете ще са до 100
        private static int defaultCapacity = 100;

        public Deque() : this(defaultCapacity) { }

        public Deque(int capacity)
        {
            frontBuffer = new T[capacity];
            backBuffer = new T[capacity];
            history = new T[2*capacity];
            BackCount = 0;
            FrontCount = 0;
            HistoryCount = 0;
        }

        public void AddBack(T item)
        {
            if (BackCount == backBuffer.Length)
                GrowBack();
            backBuffer[BackCount] = item;
            BackCount++;
        }

        private void GrowBack()
        {
            T[] newBuffer = new T[backBuffer.Length * 2];
            backBuffer.CopyTo(newBuffer, 0);
            backBuffer = newBuffer;
        }

        public void AddFront(T item)
        {
            if (FrontCount == frontBuffer.Length)
                GrowFront();
            frontBuffer[FrontCount] = item;
            FrontCount++;
        }

        private void GrowFront()
        {
            T[] newBuffer = new T[frontBuffer.Length * 2];
            frontBuffer.CopyTo(newBuffer, 0);
            frontBuffer = newBuffer;
        }

        public T GetFront()
        {
            if (FrontCount > 0)
                return frontBuffer[FrontCount - 1];
            else return null;
        }

        public T GetBack()
        {
            if (BackCount > 0)
                return backBuffer[BackCount - 1];
            else return null;
        }

        public T RemoveBack()
        {
            if (BackCount == 0)
                throw new System.ArgumentOutOfRangeException("No more items.");
            T item = GetBack();
            AddToHistory(item);
            BackCount--;
            return item;
        }

        public T RemoveFront()
        {
            if (FrontCount == 0)
                throw new System.ArgumentOutOfRangeException("No more items.");
            T item = GetFront();
            AddToHistory(item);
            FrontCount--;
            return item;
        }

        private void AddToHistory(T item)
        {
            if (HistoryCount == history.Length)
                GrowHistory(); // списъкът на заминалите влакове може да е много голям
            history[HistoryCount] = item;
            HistoryCount++;
        }

        private void GrowHistory()
        {
            T[] newBuffer = new T[history.Length * 2];
            history.CopyTo(newBuffer, 0);
            history = newBuffer;
        }
    }
}
