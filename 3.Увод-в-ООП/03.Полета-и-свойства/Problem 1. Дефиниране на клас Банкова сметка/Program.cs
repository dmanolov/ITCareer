using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Дефиниране_на_клас_Банкова_сметка
{
    class Program
    {
        static void Main(string[] args)
        {
            var acc = new BankAccount();

            acc.ID = 1;
            acc.Balance = 15;

            Console.WriteLine($"Account {acc.ID}, balance {acc.Balance}");
        }
    }
}
