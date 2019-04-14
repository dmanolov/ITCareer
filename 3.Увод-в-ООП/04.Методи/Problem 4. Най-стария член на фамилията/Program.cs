using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Методи
{
    class Program
    {
        static void Main(string[] args)
        {
            var family = new Family();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var person = new Person();
                person.Name = input[0];
                person.Age = int.Parse(input[1]);
                family.AddMember(person);
            }

            var oldest = family.GetOldestMember();
            Console.WriteLine(oldest.Name + " " + oldest.Age);
        }
    }
}
