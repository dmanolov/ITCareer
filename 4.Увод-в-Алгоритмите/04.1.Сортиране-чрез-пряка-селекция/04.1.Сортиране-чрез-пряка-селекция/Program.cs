using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._1.Сортиране_чрез_пряка_селекция
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 6, 1, 4, 3, 2, 5 };
            SelectionSort.SortI(a);
            Console.WriteLine(String.Join(",", a));

            int[] b = new int[] { 6, 1, 4, 3, 2, 5 };
            SelectionSort.SortR(b);
            Console.WriteLine(String.Join(",", b));
        }
    }
}
