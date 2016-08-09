using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using PayPal;
namespace PayPalWebFormDemo
{
    public partial class Notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Stream Come = Request.InputStream;
            byte[] ComeByte = new byte[Come.Length];
            Come.Read(ComeByte, 0, (int)Come.Length);
            string InputStr = Encoding.UTF8.GetString(ComeByte);

            if (string.IsNullOrEmpty(InputStr))
            {
                return;
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
        }
    }
}