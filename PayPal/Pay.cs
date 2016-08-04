using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace PayPal
{
    #region PayPal支付调用类
    /// <summary>
    /// Create By Asen
    /// 2016-08-04
    /// </summary>
    #endregion
    public class Pay
    {
        string Action;

        public Pay(string Action) {
            this.Action=Action;
        }

        /// <summary>
        /// 默认支付模式
        /// </summary>
        public void PostPay(PayPalObj PayObj) {
            string Params=PayHelper.GroupPayParam(PayObj);
            HttpContext.Current.Response.Redirect(Action+"?"+Params);
        }

        /// <summary>
        /// 自定义支付模式
        /// </summary>
        /// <param name="Dt_Param"></param>
        public void PostPay(Dictionary<string, string> Dt_Param)
        {
            string Params = PayHelper.GroupPayParam(Dt_Param);
            HttpContext.Current.Response.Redirect(Action + "?" + Params);
        }

    }
}
