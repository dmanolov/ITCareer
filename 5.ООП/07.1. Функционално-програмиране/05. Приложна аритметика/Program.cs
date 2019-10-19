using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Приложна_аритметика
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;
            do
            {
                command = Console.ReadLine();
                Func<int, int> operation = n => n;
                switch(command)
                {
                    case "add": operation = n => n+1; break;
                    case "multiply": operation = n => n * 2; break;
                    case "subtract": operation = n => n - 1; break;
                    case "print": operation = n => { Console.Write(n + " "); return n; }; break;
                }
                numbers = numbers.Select(operation).ToList();

            } while (command != "end");
        }
    }
}
