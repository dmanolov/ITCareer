using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Собствена_Min_функция
{
    class Program
    {
        static void Main(string[] args)
        {
            // Първи начин
            Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Min());

            // Втори начин
            Func<int[], int> min = x => x.Min();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(min(input));

            // Трети начин
            Func<List<int>, int> Min = n =>
            {
                int minValue = int.MaxValue;
                foreach (var num in n)
                {
                    if (minValue > num)
                    {
                        minValue = num;
                    }
                }
                return minValue;
            };

            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(Min(nums));
        }
    }
}
