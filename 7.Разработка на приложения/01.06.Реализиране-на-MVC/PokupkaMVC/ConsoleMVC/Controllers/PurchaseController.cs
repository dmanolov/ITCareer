using ConsoleMVC.Model;
using ConsoleMVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMVC.Controllers
{
    class PurchaseController
    {
        private Purchase purchase;
        private Display display;

        public PurchaseController()
        {
            display = new Display();
            purchase = new Purchase(display.Money, display.Price);
            display.IsSuccessful = purchase.IsSuccessful;
            display.Change = purchase.Change;
            display.ShowPurchaseResult();
        }
    }
}
