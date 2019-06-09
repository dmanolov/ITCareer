using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Наредени_двойки
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            for (int p = 1; p <= m; p++)
            {
                for (int q = p+1; q <= n; q++)
                {
                    Console.WriteLine($"({p},{q})");
                }
            }
        }
    }
}
