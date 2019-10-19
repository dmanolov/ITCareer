using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Обърни_и_изпълни
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            Func<int, bool> deliSe = x => x % n != 0;
            Console.WriteLine(string.Join(" ", numbers.Where(deliSe).Reverse()));
        }
    }
}
