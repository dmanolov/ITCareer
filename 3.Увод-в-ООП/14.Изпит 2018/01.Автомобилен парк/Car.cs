using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Автомобилен_парк
{
    class Car
    {
        private static int counter = 0;

        private string manufacturer;
        private string model;
        private double loadCapacity;
        private List<Part> parts;
        private double fuel;

        public ReadOnlyCollection<Part> Parts
        {
            get { return new ReadOnlyCollection<Part>(parts); }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                if (value.Length < 3)
                        throw new System.ArgumentException("Invalid manufacturer name!");
                    this.manufacturer = value;
            }
        }
        public string Model
        {
            get => model;
            set
            {
                if (value.Length < 3)
                    throw new System.ArgumentException("Invalid model name!");
                this.model = value;
            }
        }

        public double LoadCapacity
        {
            get => loadCapacity;
            set
            {
                if (value < 0)
                    throw new System.ArgumentException("Invalid load capacity!");
                this.loadCapacity = value;
            }
        }

        public double Price
        {
            get
            {
                return GetCarPrice();
            }
        }

        public Car(string manufacturer, string model, double loadCapacity)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.LoadCapacity = loadCapacity;
            this.parts = new List<Part>();
            this.fuel = 100;
            counter++;
        }

        public override string ToString()
        {
            var result = $"{model.ToUpper()} made by {manufacturer}" + System.Environment.NewLine;
            result += "Available parts:" + System.Environment.NewLine;
            foreach (var part in parts)
            {
                result += part.ToString() + System.Environment.NewLine;
            }
            result += $"With total price of: {GetCarPrice():F2} lv.";

            return result;
        }

        public double GetCarPrice()
        {
            return parts.Sum(part => part.Price);
        }

        public void AddPart(Part part)
        {
            parts.Add(part);
        }

        public void AddMultipleParts(List<Part> passedParts)
        {
            foreach (var part in passedParts)
                parts.Add(part);
        }

        public void RemovePartByName(string name)
        {
            // маха всички части с даденото име
            parts.RemoveAll(part => part.Name == name);

            /* може и така:
            var partToRemove = parts.SingleOrDefault(part => part.Name == name);
            if (partToRemove != null)
                parts.Remove(partToRemove); 
            */
        }

        public List<Part> GetPartsWithPriceAbove(double price)
        {
            return parts.Where(part => part.Price > price).ToList();
        }

        public Part GetMostExpensivePart()
        {
            double maxPrice = 0.0;
            Part maxPricePart = null;

            foreach (var part in parts)
            {
                if (part.Price > maxPrice)
                {
                    maxPrice = part.Price;
                    maxPricePart = part;
                }
            }

            return maxPricePart;
        }

        public static int OrdersCount
        {
            get => counter;
        }

        public void Drive(double distance)
        {
            fuel = loadCapacity * 0.2 * distance;
        }

        public bool ContainsPart(string partName)
        {
            return parts.Any(part => part.Name == partName);
        }
    }
}
