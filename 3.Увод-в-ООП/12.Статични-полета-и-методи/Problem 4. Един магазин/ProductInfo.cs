using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edin_magazin
{
    static class Product_info
    {

        private static List<Product> products = new List<Product>();

        public static Product FindProduct(string barcode)
        {
            foreach(var p in products)
            {
                if (p.Barcode == barcode)
                {
                    return p;
                }
            }
            return null;
        }
        public static void Sell(string barcode, double quantity)
        {
            var p = FindProduct(barcode);
            if ((p != null) && (p.Quantity >= quantity))
            {
                p.Quantity = p.Quantity - quantity;
            }
            else {
                Console.WriteLine("Not enough quantity");
            }
        }
        public static void Add(string barcode, string name , double price , double quantity)
        {
            products.Add(new Product(name, barcode, price, quantity));
        }
        
        public static void Update(string barcode, double quantity)
        {
            var p = FindProduct(barcode);
            if (p != null)
            {
                p.Quantity = p.Quantity + quantity;
            }
            else
            {
                Console.WriteLine("Please add your product first!");
            }
        }

        // Изпечатване на налични продукти по азбучен ред(PrintA)
        public static void PrintA()
        {
            foreach(var p in products.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{p.Name} ({p.Barcode})");
            } 
        }

        // Изпечатване на информация за неналични продукти по азбучен ред(PrintU)
        public static void PrintU()
        {
            foreach (var p in products.OrderBy(p => p.Name))
            {
                if(p.Quantity == 0)
                    Console.WriteLine($"{p.Name} ({p.Barcode})");
            }
        }

        // Изпечатване на всички продукти по намаляща наличност - тези от които 
        // има най-много са в началото(PrintD)
        public static void PrintD()
        {
            foreach (var p in products.OrderByDescending(p => p.Quantity))
            {
                Console.WriteLine($"{p.Name} ({p.Barcode})");
            }
        }
        // Изчисляване на стойността на всички налични продукти(Calculate)
        public static double Calculate()
        {
            double totalAmount = 0;
            foreach (var p in products)
            {
                totalAmount += p.Price * p.Quantity;
            }
            return totalAmount;
        }

    }
}
