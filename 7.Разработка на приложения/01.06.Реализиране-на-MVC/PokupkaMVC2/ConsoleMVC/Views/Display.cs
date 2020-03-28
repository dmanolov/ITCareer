using ConsoleMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMVC.Views
{
    class Display
    {
        private Purchase purchase;
        
        public Display(Purchase purchase)
        {
            this.purchase = purchase;
        }

        public void ShowWellcomeMessage()
        {
            Console.WriteLine(purchase.WelcomeMessage);
            Console.WriteLine("How many purchaces you plan to make:");
            purchase.PurchaseCount = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        public void ShowGoodbuyMessage()
        {
            Console.WriteLine();
            Console.WriteLine(purchase.GoodbuyMessage);
        }

        public void ReadInputData()
        {
            Console.WriteLine("How much money you have:");
            purchase.Money = double.Parse(Console.ReadLine());
            Console.WriteLine("What is the price: ");
            purchase.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("What is the quantity: ");
            purchase.Quantity = int.Parse(Console.ReadLine());
        }

        public void ShowPurchaseResult()
        {
            if(purchase.IsSuccessful)
                Console.WriteLine("Purchase is successful! Change is: {0:C}", purchase.Change);
            else 
                Console.WriteLine("Purchase is not successful!");
        }
    }
}
