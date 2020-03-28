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
            // създаваме изгледа и модела
            purchase = new Purchase();
            display = new Display(purchase);

            display.ShowWellcomeMessage();
            for (int i = 0; i < purchase.PurchaseCount; i++)
            {
                // чета входните данни от изгледа и ги предава към модела
                display.ReadInputData();
                // извършвам пресмятанията в модела
                purchase.PurchaseAttempt();
                // предавам информацията към изгледа и извеждам резултата в изгледа
                display.ShowPurchaseResult();
            }
            display.ShowGoodbuyMessage();
        }
    }
}
