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
            Person p1 = new Person();
            p1.name = "Pesho";
            p1.age = 20;

            Person p2 = new Person();
            p2.name = "Gosho";
            p2.age = 18;

            Person p3 = new Person();
            p3.name = "Stamat";
            p3.age = 43;
        }
    }
}
