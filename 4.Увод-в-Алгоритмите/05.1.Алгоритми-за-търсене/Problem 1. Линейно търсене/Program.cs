using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Линейно_търсене
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int key = int.Parse(Console.ReadLine());
            // извикваме метода за линейно търсене
            Console.WriteLine(LinearSearch(arr, key));
            // същото, написано директно в кода
            int keyIndex = -1; // отначало решаваме, че го няма
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key)
                {
                    keyIndex = i;   // запомняме на коя позиция е
                    break;          // няма смисъл да търсим нататък
                }
            }
            Console.WriteLine(keyIndex);
        }

        static int LinearSearch(int[] arr, int key)
        {
            // обхождаме масива
            for (int i = 0; i < arr.Length; i++)
            {
                // ако намериме числото, връщаме индекса
                if (arr[i] == key)
                {
                    return i;
                }
            }
            // като завърши цикъла, връщаме, че го няма
            return -1;
        }
    }
}
