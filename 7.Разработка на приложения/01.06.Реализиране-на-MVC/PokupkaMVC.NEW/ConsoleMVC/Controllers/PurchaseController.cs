using PurchaceMVC.Model;
using PurchaceMVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaceMVC.Controllers
{ 
    class PurchaseController
    {
        private Purchase purchase;
        private Display display;

        public PurchaseController()
        {
            display = new Display();
            purchase = new Purchase();
            for (int i = 0; i < display.PurchaseCount; i++)
            {
                display.ReadInput();
                purchase.Money = display.Money;
                purchase.Price = display.Price;
                purchase.TryToOrder();
                display.IsSuccessful = purchase.IsSuccessful;
                display.Change = purchase.Change;
                display.ShowPurchaseResult();
            }
        }
    }
}
