using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Рицари_на_честта
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printLine = text => Console.WriteLine($"Sir {text}");
            Console.ReadLine().Split().ToList().ForEach(printLine);

        }
    }
}
