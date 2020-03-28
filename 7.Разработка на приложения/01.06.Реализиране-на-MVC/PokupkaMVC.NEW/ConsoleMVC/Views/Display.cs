using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaceMVC.Views
{
    class Display
    {
        const double ProgramVersion = 1.00;

        public double Price { get; set; }
        public double Money { get; set; }
        public double Change { get; set; }
        public bool IsSuccessful { get; set; }
        public int PurchaseCount { get; set; }

        public Display()
        {
            Price = 0;
            Money = 0;
            Change = 0;
            IsSuccessful = false;
            ReadSetupInfo();
        }

        public void ReadSetupInfo()
        {
            Console.WriteLine("How many purchaces you plan to make:");
            PurchaseCount = int.Parse(Console.ReadLine());
        }

        public void ReadInput()
        {
            Console.WriteLine("How much money you have:");
            Money = double.Parse(Console.ReadLine());
            Console.WriteLine("What is the price: ");
            Price = double.Parse(Console.ReadLine());
        }

        public void ShowPurchaseResult()
        {
            if(IsSuccessful)
                Console.WriteLine("Purchase is successful! Change is: {0:C}", Change);
            else 
                Console.WriteLine("Purchase is not successful!");
        }
    }
}
