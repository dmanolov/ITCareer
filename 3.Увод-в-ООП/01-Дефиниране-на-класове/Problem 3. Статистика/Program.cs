using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Статистика
{
    class Program
    {
        static void Main(string[] args)
        {
            var family = new Family();
            int number = int.Parse(Console.ReadLine());

            while (number > 0)
            {
                var line = Console.ReadLine().Split();

                var person = new Person();
                person.name = line[0];
                person.age = int.Parse(line[1]);

                family.members.Add(person);
                number--;
            }

            var sorted = family.members.OrderBy(o => o.name).ToList();

            Console.WriteLine();
            foreach (var person in sorted)
            {
                if(person.age > 30)
                    Console.WriteLine(person.name + ' ' + person.age);
            }
        }
    }
}
