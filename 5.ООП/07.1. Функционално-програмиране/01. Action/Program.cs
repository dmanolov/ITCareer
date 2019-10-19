using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Action
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printLine = text => Console.WriteLine(text);
            Console.ReadLine().Split().ToList().ForEach(printLine);
        }
    }
}
