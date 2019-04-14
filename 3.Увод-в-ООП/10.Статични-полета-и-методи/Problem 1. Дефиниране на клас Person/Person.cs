using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Дефиниране_на_клас_Person
{
    class Person
    {
        private static int count;

        private string name;
        private int age;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Age
        {
            get => age;
        }
        public static int Count
        {
            get => count;
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            count++;
        }
    }
}
