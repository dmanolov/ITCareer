using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._1.Сортиране_чрез_пряка_селекция
{
    public class SelectionSort
    {
        // сортиране по метода на пряката селекция чрез итерации (цикъл)
        public static void SortI<T>(T[] a) where T: IComparable<T>
        {
            // правим това за първия, втория и т.н. до предпоследния
            for (int index = 0; index < a.Length - 1; index++)
            {
                // Намираме най-малката стойност в масива от този до края
                int min = index;
                for (int i = index+1; i < a.Length; i++)
                {
                    if (Less((IComparable)a[i], (IComparable)a[min]))
                        min = i;
                }
                // разменяме я с дадения елемент
                Swap(a, index, min);
            }
        }

        // рекурсивно сортиране по метода на пряката селекция
        public static void SortR<T>(T[] a) where T : IComparable<T>
        {
            Sort(a, 0, a.Length - 1);
        }

        // рекурсивен метод за сортиране
        private static void Sort<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            // намираме най-малкия елемент от lo до hi
            int min = lo;
            for (int i = lo + 1; i <= hi; i++)
            {
                if (Less((IComparable)arr[i], (IComparable)arr[min]))
                    min = i;
            }
            // разменяме му мястото с lo
            Swap(arr, lo, min);
            // докато не изчерпим масива (дъно на рекурсията)
            if (lo >= hi) return;
            // правим същото за останалите (рекурсивно извикване)
            Sort(arr, lo + 1, hi);
        }

        // проверка кой е по-малкия елемент
        static bool Less(IComparable first, IComparable second)
        {
            return first.CompareTo(second) < 0;
        }

        // разменяме местата на двата елемента
        static void Swap<T>(T[] collection, int from, int to)
        {
            if (from == to) return;

            T swap = collection[from];
            collection[from] = collection[to];
            collection[to] = swap;
        }
    }
}
