using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Статистическо_проучване
{
    class People
    {
        private static List<Person> people = new List<Person>();

        public void Add(string name, int age)
        {
            people.Add(new Person(name, age));
        }

        public void PrintAllAboveAge(int age)
        {
            foreach(var p in people.OrderBy(p => p.Name))
            {
                if (p.Age > age)
                {
                    Console.WriteLine("{0} - {1}", p.Name, p.Age);
                }
            }
        }

    }
}
