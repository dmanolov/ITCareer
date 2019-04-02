using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Добавяне_на_методи_към_класа_Банкова_сметка
{
    class Program
    {
        static void Main(string[] args)
        {
            var acc = new BankAccount();

            acc.ID = 1;
            acc.Deposit(15);
            acc.Withdraw(5);
            Console.WriteLine(acc);
        }
    }
}
