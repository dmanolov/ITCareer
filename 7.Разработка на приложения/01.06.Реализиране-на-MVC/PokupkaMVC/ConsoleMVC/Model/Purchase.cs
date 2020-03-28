using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMVC.Model
{
    class Purchase
    {
        private double price;
        private double money;
        public double Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Price cannot be negative");
                }
                this.price = value;
            }
        }
        public double Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public double Change
        {
            get
            {
                if (IsSuccessful)
                    return Money - Price;
                else return 0;  // няма сделка, няма и ресто
            }
        }
        public bool IsSuccessful
        {
            get { return Money >= Price; }
        }

        public Purchase(double money, double price)
        {
            Money = money;
            Price = price;
        }
        public Purchase() : this(0, 0) { }
    }
}
