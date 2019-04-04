﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Проверка_на_данните
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private double salary;

        public string FirstName
        {
            get { return firstName; }
            set {
                if(value.Length < 3 )
                    throw new ArgumentException("First name cannot be less than 3 symbols");
                firstName = value;
            } 
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Last name cannot be less than 3 symbols");
                lastName = value;
            }
        }
        public string Name
        {
            get => firstName + " " + lastName;
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Age cannot be zero or negative integer.");
                age = value;
            }
        }
        public double Salary
        {
            get { return salary; }
            set
            {
                if(value < 460)
                    throw new ArgumentException("Salary cannot be less than 460 leva.");
                salary = value;
            }
        }

        public Person(string firstName, string lastName, int age, double salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public void IncreaseSalary(double bonus)
        {
            if (age < 30)
                Salary += Salary * (bonus / 200);
            else Salary += Salary * (bonus / 100);
        }
        public override string ToString()
        {
            return $"{Name} get {Salary:0.00} leva";
        }
    }
}
