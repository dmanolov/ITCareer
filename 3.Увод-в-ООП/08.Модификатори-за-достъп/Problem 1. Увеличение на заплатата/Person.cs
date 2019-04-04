using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Увеличение_на_заплатата
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private double salary;

        public string Name
        {
            get => firstName + " " + lastName;
        }
        public int Age
        {
            get => age;
        }
        public double Salary
        {
            get => salary;
        }

        public Person(string firstName, string lastName, int age, double salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
        }
        public void IncreaseSalary(double bonus)
        {
            if (age < 30)
                salary += salary*(bonus / 200);
            else salary += salary * (bonus / 100);
        }
        public override string ToString()
        {
            return $"{Name} get {Salary:0.00} leva";
        }
    }
}
