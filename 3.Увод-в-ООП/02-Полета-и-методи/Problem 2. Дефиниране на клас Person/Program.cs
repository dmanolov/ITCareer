using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Дефиниране_на_клас_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "Pesho";
            p1.Age = 20;

            Person p2 = new Person();
            p2.Name = "Gosho";
            p2.Age = 18;

            Person p3 = new Person();
            p3.Name = "Stamat";
            p3.Age = 43;
        }
    }
}
