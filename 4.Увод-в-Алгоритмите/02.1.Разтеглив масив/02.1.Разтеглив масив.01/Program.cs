using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._1.Разтеглив_масив._01
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> list = new ArrayList<int>();
            list.Add(5);
            list.Add(10);
            list.Add(15);
            list[0] = list[0] + 1;
            int element = list.RemoveAt(0);
            Console.WriteLine(element);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
