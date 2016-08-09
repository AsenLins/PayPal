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
        /// <summary>
        /// 访问PayPal支付的地址（sandBox地址或者正式地址）
        /// </summary>
        string Action;

        public Pay(string Action) {
            this.Action=Action;
        }

        #region 默认支付模式
        /// <summary>
        /// 默认支付模式
        /// </summary>
        /// <param name="PayObj">支付参数对象</param>
        public void PostPay(PayPalObj PayObj) {
            string Params=PayHelper.GroupPayParam(PayObj);
            HttpContext.Current.Response.Redirect(Action+"?"+Params);
        }
        #endregion

        #region 自定义支付模式
        /// <summary>
        /// 自定义支付模式
        /// </summary>
        /// <param name="Dt_Param">参数字典</param>
        public void PostPay(Dictionary<string, string> Dt_Param)
        {
            string Params = PayHelper.GroupPayParam(Dt_Param);
            HttpContext.Current.Response.Redirect(Action + "?" + Params);
        }
        #endregion

        #region 验证IPN消息
        /// <summary>
        /// 验证IPN消息
        /// </summary>
        /// <param name="Stream"></param>
        /// <returns></returns>
        public bool IPNVierfy(string Stream)
        {
            StringBuilder StrParam = new StringBuilder(Stream);
            StrParam.Insert(0, "cmd=_notify-validate&");
            string Result = PayHelper.PostRequest(Action, "POST", StrParam.ToString(), "utf-8");
            if (Result == "VERIFIED")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 把IPN发送过来的参数组成字典,方便访问
        /// <summary>
        /// 把IPN发送过来的参数组成字典,方便访问
        /// </summary>
        /// <param name="ParamsStr">IPN发送过来的字符串参数</param>
        /// <returns>字典参数集合</returns>
        public Dictionary<string, string> GroupIpnMessage(string ParamsStr)
        {
            Dictionary<string, string> Dt_Param = new Dictionary<string, string>();
            string[] StrParams = ParamsStr.Split('&');
            for (int i = 0; i < StrParams.Length; i++)
            {
                string[] StrKeyValue = StrParams[i].Split('=');
                Dt_Param.Add(StrKeyValue[0], StrKeyValue[1]);
            }
            return Dt_Param;
        }
        #endregion 

    }
}
