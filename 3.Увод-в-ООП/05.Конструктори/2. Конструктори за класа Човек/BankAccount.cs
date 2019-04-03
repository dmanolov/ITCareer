using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Конструктори_за_класа_Човек
{
    class BankAccount
    {
        private int id;
        private double balance;

        public int ID
        {
            get => id;
        }
        public double Balance { get => balance; }

        public BankAccount(int id) : this(id, 0) { }
        public BankAccount(int id, double balance)
        {
            this.id = id;
            this.balance = balance;
        }
        
    }
}
