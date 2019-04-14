using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Дефиниране_на_клас_Person
{
    class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public void IntroduceYourself()
        {
            Console.WriteLine($"My name is {name} and I'm {age}");
        }
    }
}
