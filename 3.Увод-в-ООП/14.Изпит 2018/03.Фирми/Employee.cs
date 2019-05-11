using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Фирми
{
    class Employee
    {
        private string id;
        private string firstName;
        private string lastName;
        private int age;
        private double salary;

        public string Id
        {
            get => id;
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (value.Length > 2 && value.Length < 8)
                    firstName = value;
                else throw new System.ArgumentException("Invalid employee name");
            }
        }
        public string LastName
        {
            get => lastName;
        }
        public int Age
        {
            get => age;
            set
            {
                if (value > 0)
                    age = value;
                else throw new System.ArgumentException("Invalid employee age");
            }
        }
        public double Salary
        {
            get => salary;
            set => salary = value;
        }

        public Employee(string id, string firstName, string lastName, int age)
            : this(id, firstName, lastName, age, 500.0)
        {
        }

        public Employee(string id, string firstName, string lastName, int age, double salary)
            
        {
            this.id = id;
            this.FirstName = firstName;
            this.lastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"Employee: {firstName} {lastName} with id: {id} and salary: {salary:F2}";
        }


    }
}
