using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._02._01.Сортиране_чрез_метод_на_мехурчето
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr;
            int swapCounts;

            // среден случай, с итерации
            arr = new int[] { 6, 1, 4, 3, 2, 5 };
            swapCounts = BubbleSort.SortI(arr);
            Console.WriteLine("Масивът: " + String.Join(",", arr) + " Размени: " + swapCounts);

            // най-добър случай, с итерации
            arr = new int[] { 1, 2, 3, 4, 5, 6 };
            swapCounts = BubbleSort.SortI(arr);
            Console.WriteLine("Масивът: " + String.Join(",", arr) + " Размени: " + swapCounts);

            // най-лош случай, с итерации
            arr = new int[] { 6, 5, 4, 3, 2, 1 };
            swapCounts = BubbleSort.SortI(arr);
            Console.WriteLine("Масивът: " + String.Join(",", arr) + " Размени: " + swapCounts);

            // среден случай, с рекурсия
            arr = new int[] { 6, 1, 4, 3, 2, 5 };
            swapCounts = BubbleSort.SortR(arr);
            Console.WriteLine("Масивът: " + String.Join(",", arr) + " Размени: " + swapCounts);

            // най-добър случай, с рекурсия
            arr = new int[] { 1, 2, 3, 4, 5, 6 };
            swapCounts = BubbleSort.SortR(arr);
            Console.WriteLine("Масивът: " + String.Join(",", arr) + " Размени: " + swapCounts);

            // най-лош случай, с рекурсия
            arr = new int[] { 6, 5, 4, 3, 2, 1 };
            swapCounts = BubbleSort.SortR(arr);
            Console.WriteLine("Масивът: " + String.Join(",", arr) + " Размени: " + swapCounts);

        }
    }
}
