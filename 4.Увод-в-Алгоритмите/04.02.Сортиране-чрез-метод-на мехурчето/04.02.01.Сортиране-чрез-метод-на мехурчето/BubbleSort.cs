using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._02._01.Сортиране_чрез_метод_на_мехурчето
{
    public class BubbleSort
    {
        // сортиране по метода на мехурчето чрез итерации (цикъл)
        public static int SortI<T>(T[] a) where T : IComparable<T>
        {
            // искаме да броим колко пъти има размяна
            int swapCount = 0;
            // отначало сме до предпоследния
            int last = a.Length - 1;
            // Това се повтаря до подреждането на масива
            while (last >= 0)
            {
                // брой размени при текущото обхождане
                int currSwapCount = 0;
                // Обхождаме целия масив и сравняваме всеки 2 съседни елемента
                for (int i = 0; i < last; i++)
                {
                    // Ако текущия е по-голям от следващия, те разменят местата си
                    if (Less((IComparable)a[i + 1], (IComparable)a[i]))
                    {
                        Swap(a, i, i + 1);
                        currSwapCount++;
                    }
                }
                // щом няма размяна, значи е сортиран, приключваме
                if (currSwapCount == 0) break;
                // да проследим колко общо са размените
                swapCount += currSwapCount;
                // последният е подреден, сортираме всички до него
                last--;
            }
            return swapCount;
        }

        // рекурсивно сортиране по метода на мехурчето
        public static int SortR<T>(T[] a) where T : IComparable<T>
        {
            return Sort(a, a.Length - 1);
        }

        // рекурсивен метод за сортиране
        private static int Sort<T>(T[] arr, int last) where T : IComparable<T>
        {
            // дъно на рекурсията - ако няма елементи за сравнение
            if (last == 0) return 0;
            // искаме да броим колко пъти има размяна
            int swapCount = 0;
            for (int i = 0; i < last; i++)
            {
                // Ако текущия е по-голям от следващия, те разменят местата си
                if (Less((IComparable)arr[i + 1], (IComparable)arr[i]))
                {
                    Swap(arr, i, i + 1);
                    swapCount++;
                }
            }
            // ако не е имало размяна, значи вече е сортиран
            if (swapCount == 0) return 0;
            // сортираме предишните преди последния, който вече е подреден
            return swapCount + Sort(arr, last - 1);
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
