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
            var myMan = new Person();

            myMan.Name = "Gosho";
            myMan.Age = 16;

            myMan.IntroduceYourself();
        }
    }
}
