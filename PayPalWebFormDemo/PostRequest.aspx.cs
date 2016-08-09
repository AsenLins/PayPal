using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal;

namespace PayPalWebFormDemo
{
    public partial class PostRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

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

        }
    }
}