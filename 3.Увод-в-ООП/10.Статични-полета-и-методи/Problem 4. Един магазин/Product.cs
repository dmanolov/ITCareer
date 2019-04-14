using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edin_magazin
{
    class Product
    {
        private string name;
        private string barcode;
        private double price;
        private double quantity;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Barcode
        {
            get => barcode;
        }
        public double Price
        {
            get => price;
        }
        public double Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public Product (string name , string barcode , double price , double quantity)
        {
            this.name = name;
            this.barcode = barcode;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
