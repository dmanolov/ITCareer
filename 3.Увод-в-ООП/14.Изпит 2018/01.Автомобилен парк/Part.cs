using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Автомобилен_парк
{
    class Part
    {
        private string name;
        private double price;
        
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 5)
                    throw new System.ArgumentException("Invalid part name!");
                this.name = value;
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0.0)
                    throw new System.ArgumentException("Price should be positive!");
                this.price = value;
            }
        }

        public Part(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Part(string name) : this(name, 25) { }

        public override string ToString()
        {
            return $"-> {name} - {price:F2}";
        }
    }
}
