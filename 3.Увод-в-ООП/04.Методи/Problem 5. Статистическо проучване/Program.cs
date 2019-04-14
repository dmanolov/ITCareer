using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Статистическо_проучване
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new People();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);

                people.Add(name, age);
            }

            people.PrintAllAboveAge(30);
        }
    }
}
