using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaceMVC.Model
{
    class Purchase
    {
        private static int initialQuantity = 3;

        private double price;
        private double money;
        private int quantity;

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Quantity cannot be negative");
                }
                this.quantity = value;
            }
        }

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
        public void TryToOrder()
        {
            IsSuccessful = (Money >= Price) && (Quantity > 0);
            if(IsSuccessful)
            {
                Change = Money - Price;
                Quantity--;
            }
        }
        public double Change { get; private set; }
        public bool IsSuccessful { get; private set;  }

        public Purchase(double money, double price)
        {
            Money = money;
            Price = price;
            quantity = initialQuantity;
        }
        public Purchase() : this(0, 0) { }
    }
}
