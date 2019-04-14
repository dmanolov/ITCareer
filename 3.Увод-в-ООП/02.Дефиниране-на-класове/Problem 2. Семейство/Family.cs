using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Семейство
{
    class Family
    {
        public List<Person> members = new List<Person>();

        public void Print()
        {
            foreach (var person in members)
            {
                Console.WriteLine(person.name + ' ' + person.age);
            }
        }
    }
}
