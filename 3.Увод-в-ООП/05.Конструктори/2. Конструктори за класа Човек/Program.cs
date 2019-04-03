using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Конструктори_за_класа_Човек
{
    class Program
    {
        static void Main(string[] args)
        {
            var acc = new BankAccount(1, 1000);
            var accounts = new List<BankAccount>();
            accounts.Add(acc);

            var people = new List<Person>();
            people.Add(new Person("Krisi", 16));
            people.Add(new Person("Gosho"));
            people.Add(new Person(17));
            people.Add(new Person());
            people.Add(new Person("Ivan", 28, accounts));

            people.ForEach(item => item.IntroduceYourself());
        }
    }
}
