using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Двоично_търсене
{
    class Program
    {
        static int keyNotFound = -1;

        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int key = int.Parse(Console.ReadLine());
            // извикваме методите за двоично търсене
            Console.WriteLine(BinarySearchI(arr, key, 0, arr.Length - 1));
            Console.WriteLine(BinarySearchR(arr, key, 0, arr.Length - 1));
        }

        // двоично търсене - вариант с итерации
        static int BinarySearchI(int[] arr, int key, int start, int end)
        {
            while (end >= start)
            {
                int mid = (start + end) / 2;
                if (arr[mid] < key)
                    start = mid + 1;
                else if (arr[mid] > key)
                    end = mid - 1;
                else
                    return mid;
            }
            return keyNotFound;
        }

        // двоично търсене - рекурсивен вариант
        static int BinarySearchR(int[] arr, int key, int start, int end)
        {
            if (end < start)
                return keyNotFound;
            else
            {
                int mid = (start + end) / 2;
                if (arr[mid] > key)
                    return BinarySearchR(arr, key, start, mid - 1);
                else if (arr[mid] < key)
                    return BinarySearchR(arr, key, mid + 1, end);
                else
                    return mid;
            }
        }

    }
}