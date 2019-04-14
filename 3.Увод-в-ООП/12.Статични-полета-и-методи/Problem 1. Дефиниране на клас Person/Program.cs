using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Дефиниране_на_клас_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            var pesho = new Person("Pesho", 22);
            Console.WriteLine(Person.Count + " is born");

            var gosho = new Person("Gosho", 38);
            Console.WriteLine(Person.Count + " are born");
        }
    }
}
