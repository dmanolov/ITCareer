using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1.Дефиниране_на_интерфейс_IPerson
{
    interface IPerson
    {
        string Name { get; }
        int Age { get; }
    }
    public class Citizen : IPerson
    { 
        public string Name { get; set; }
        public int Age { get; set; }
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Type personInterface = typeof(Citizen).GetInterface("IPerson");
            PropertyInfo[] properties = personInterface.GetProperties();
            Console.WriteLine(properties.Length);
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            IPerson person = new Citizen(name, age);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);

        }
    }
}
