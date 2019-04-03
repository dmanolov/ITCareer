using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Конструктори_за_класа_Човек
{
    class Person
    {
        private string name;
        private int age;
        private List<BankAccount> accounts;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Age
        {
            get => age;
            private set => age = value;
        }

        public void GettingOlder()
        {
            age++;
        }
        public double GetBalance()
        {
            double sum = 0;
            //sum = accounts.Sum(item => item.Balance);
            foreach (var acc in accounts)
            {
                sum += acc.Balance;
            }
            return sum;
        }
        public void IntroduceYourself()
        {
            Console.WriteLine($"I'm {name} and I'm {age} "+
                              $"years old and I have {GetBalance()} in my bank accounts.");
        }

        public Person() : this("No name", -1) { }
        public Person(string name) : this(name, -1) { }
        public Person(int age) : this("No name", age) { }
        public Person(string name, int age) :
                      this(name, age, new List<BankAccount>()) { }
        public Person(string name, int age, 
                     List<BankAccount> accounts)
        {
            this.name = name;
            this.age = age;
            this.accounts = accounts;
        }
    }
}
