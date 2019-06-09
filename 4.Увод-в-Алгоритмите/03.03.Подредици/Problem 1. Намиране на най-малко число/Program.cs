using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Намиране_на_най_малко_число
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Console.WriteLine("Min value is " + MinValue(list));
        }

        public static int MinValue(List<int> list)
        {
            if (list.Count == 0)
                throw new System.ArgumentException("The list is empty");
            int min = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < min)
                    min = list[i];
            }
            return min;
        }
    }
}
