using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayPal;
namespace PayPalDemo.Controllers
{
    public class PayPalController : Controller
    {
        // GET: /PayPal/

        public ActionResult Demo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult PostPay() {

            Pay PayPal = new Pay(Request.Form["url"]);

            PayPal.PostPay(new PayPalObj()
            {
                business = Request.Form["business"],
                item_name = Request.Form["item_name"],
                quantity = Request.Form["quantity"],
                amount = Request.Form["amount"],
                currency_code = Request.Form["currency_code"],
                return_url = Request.Form["return"],
                notify_url = Request.Form["notify_url"],
                cancel_return = Request.Form["cancel_return"],
                charset = Request.Form["charset"]
            });

            return View();
        }

    }
}
