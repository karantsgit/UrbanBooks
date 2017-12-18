using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrbanBooks.Entity;

namespace UrbanBooks.Web.Controllers
{
    public class PayPalController : Controller
    {
        // GET: PayPal
        public ActionResult ValidateCommand(string product = "Test Product", string totalPrice = "200", string quantity = "2")
        {
            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
            var paypal = new PayPalModel(useSandbox);

            paypal.item_name = product;
            paypal.amount = totalPrice;
            paypal.item_quantity = quantity;
            return View(paypal);
        }

        public ActionResult RedirectFromPaypal()
        {
            return View();
        }

        public ActionResult CancelFromPaypal()
        {
            return View();
        }

        public ActionResult NotifyFromPaypal()
        {
            return View();
        }
    }
}