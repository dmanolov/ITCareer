using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class CapacityList
    {
        private const int InitialCapacity = 2;
        private Pair[] items;

        private int startIndex = 0; //показва първият индекс, от който започваме да сумираме текущите елементи
        private int nextIndex = 0; //показва поредният индекс, на който можем да поставим елемент

        public CapacityList(int capacity = InitialCapacity)
        {
            this.items = new Pair[capacity];
        }
        public int Count
        {
            get => startIndex;
        }

        private Pair SumPairs(int startIndex, int endIndex)
        {
            // сумира двойките от startIndex до endIndex
            Pair sum = new Pair(0, 0);
            for (int i = startIndex; i < endIndex; i++)
            {
                sum.First = sum.First + items[i].First;
                sum.Last = sum.Last + items[i].Last;
            }
            return sum;
        }

        public Pair SumIntervalPairs()
        {
            // сумира двойките от startIndex до nextIndex
            return SumPairs(startIndex, nextIndex);
        }

        public Pair Sum()
        {
            // сумира двойките от 0 до this.Count – 
            // всички двойки, които имат право да участват в класирането
            return SumPairs(0, this.Count);
        }

        public void Add(Pair item)
        {
            // ако няма място, сумираме двойките за да освободим такова   
            if(nextIndex == items.Length)
            {
                // сумиране на двойките от зарове
                Pair sum = SumIntervalPairs();
                items[startIndex].First = sum.First;
                items[startIndex].Last = sum.Last;
                // тази двойка вече няма да участва в сумите от зарове
                startIndex++;
                nextIndex = startIndex;
            }
            // ако и след сумирането няма място, край на играта
            if (startIndex == items.Length)
                throw new System.IndexOutOfRangeException("Game over, no more place");
            // добавяне на двойката   
            items[nextIndex] = item;
            nextIndex++;
        }

        public void PrintCurrentState()
        {
            // отпечатва всички двойки от 0 до nextIndex
            for (int i = 0; i < nextIndex; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}
