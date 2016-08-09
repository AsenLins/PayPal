using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using PayPal;
namespace PayPalDemo.Controllers
{
    public class IPNController : Controller
    {
        /*用于接收IPN的消息的页面*/
        public ActionResult Notify() {

            Stream Come = Request.InputStream;
            byte[] ComeByte = new byte[Come.Length];
            Come.Read(ComeByte, 0, (int)Come.Length);
            string InputStr = Encoding.UTF8.GetString(ComeByte);

            if (string.IsNullOrEmpty(InputStr))
            {
                return View();
            }

            try
            {
                /*填写PayPal的sandbox地址或者正式地址*/
                Pay _Pay = new Pay("https://www.sandbox.paypal.com/cgi-bin/webscr");
                
                /*必须要验证通过,才是可靠的IPN消息。*/
                if (_Pay.IPNVierfy(InputStr))
                {
                    Dictionary<string, string> GroupIpnMessage = _Pay.GroupIpnMessage(InputStr);

                    /*执行数据库操作/或其他操作....*/

                }
                else
                {
                    /*IPN消息验证不通过...*/
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        
        }

    }
}
