using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMVC.Model
{
    class Purchase
    {
        private const int InitialQuantity = 3;

        private double price;
        private double money;
        private int purchaseCount;
        private int quantityInStore = InitialQuantity;
        private int quantity;

        public int PurchaseCount
        {
            get { return this.purchaseCount; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Purchase count cannot be negative");
                }
                this.purchaseCount = value;
            }
        }
        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Quantity count cannot be negative");
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
        public double Change { get; private set; }
        public bool IsSuccessful { get; private set; }
        public string WelcomeMessage
        {
            get { return "Welcome to our shop!"; }
        }
        public string GoodbuyMessage
        {
            get { return "Come again! Have a nice day!"; }
        }

        public void PurchaseAttempt()
        {
            IsSuccessful = (Money >= Price) && (quantity <= quantityInStore);
            if (IsSuccessful)
            {
                quantityInStore -= Quantity;
                Change = Money - Price*Quantity;
            }
            else
            {
                Change = 0;
            }
        }

        public Purchase(double money, double price)
        {
            Money = money;
            Price = price;
        }
        public Purchase() : this(0, 0) { }
    }
}
