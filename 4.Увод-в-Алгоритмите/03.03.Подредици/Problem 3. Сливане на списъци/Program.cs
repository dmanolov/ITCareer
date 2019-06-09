using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Сливане_на_списъци
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> merged = new List<int>();
            int i1 = 0, i2 = 0;
            while(i1 < list1.Count && i2 < list2.Count)
            {
                if(list1[i1] <= list2[i2])
                {
                    merged.Add(list1[i1]);
                    i1++;
                }
                else
                {
                    merged.Add(list2[i2]);
                    i2++;
                }
            }
            while (i1 < list1.Count)
            {
                merged.Add(list1[i1]);
                i1++;
            }
            while (i2 < list2.Count)
            {
                merged.Add(list2[i2]);
                i2++;
            }
            Console.WriteLine(String.Join(", ", merged));
        }
    }
}
