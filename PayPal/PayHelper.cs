using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;


namespace PayPal
{
    #region PayPal支付帮助类
    /// <summary>
    /// Create By Asen
    /// Times:2016-08-04
    /// </summary>
    #endregion
    internal static class PayHelper
    {

        #region 发送web请求验证IPN支付消息/使用TSL 1.2
        /// <summary>
        /// 发送web请求验证IPN支付消息/Tsl1.2
        /// </summary>
        /// <param name="Url">请求地址</param>
        /// <param name="Method">Post/Get请求</param>
        /// <param name="parame">参数</param>
        /// <param name="EncodeStr">编码方式</param>
        /// <returns>返回的字符串</returns>
        public static string PostRequest(string Url, string Method, string parame, string EncodeStr)
        {
            /*.net 4.5版本才有枚举值Tsl1.2,以下版本就用以下方法获取Tsl1.2,如果报异常,请安装.net框架4.5即可*/
            System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string Result = "";

            if (Method == "GET")
            {
                Url = Url + "?" + parame;
            }
            /*构建请求*/
            Stream StrInput = null;
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = Method;

            if (Method == "POST")
            {
                byte[] data = Encoding.GetEncoding(EncodeStr).GetBytes(parame);
                myRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                myRequest.ContentLength = data.Length;
                Stream newStream = myRequest.GetRequestStream();
                /*发送请求*/
                newStream.Write(data, 0, data.Length);
                newStream.Close();
            }
            /*获取请求返回数据*/
            StrInput = myRequest.GetResponse().GetResponseStream();
            StreamReader StrRead = new StreamReader(StrInput);
            Result = StrRead.ReadToEnd();
            StrRead.Close();
            return Result;

        }
        #endregion

        #region 把支付对象转换为url参数
        /// <summary>
        /// 【方法】把支付对象转换为url参数
        /// </summary>
        /// <param name="PayObj">PayPal支付对象</param>
        /// <returns>url参数</returns>
        public static string GroupPayParam(PayPalObj PayObj) {
            StringBuilder StrParam = new StringBuilder();
            StrParam.Append("amount=").Append(PayObj.amount);
            StrParam.Append("&").Append("business=").Append(PayObj.business);
            StrParam.Append("&").Append("charset=").Append(PayObj.charset);
            StrParam.Append("&").Append("currency_code=").Append(PayObj.currency_code);
            StrParam.Append("&").Append("cancel_return=").Append(PayObj.cancel_return);
            StrParam.Append("&").Append("return=").Append(PayObj.return_url);
            StrParam.Append("&").Append("notify_url=").Append(PayObj.notify_url);
            StrParam.Append("&").Append("quantity=").Append(PayObj.quantity);
            StrParam.Append("&").Append("custom=").Append(PayObj.custom);
            StrParam.Append("&").Append("item_name=").Append(PayObj.item_name);
            StrParam.Append("&").Append("cmd=").Append(PayObj.cmd);
            return StrParam.ToString();
        }
        #endregion 

        #region 把支付对象转换为url参数(重载)
        /// <summary>
        /// 【方法】把支付对象转换为url参数
        /// </summary>
        /// <param name="Dt_PayParam">PayPal支付字典对象</param>
        /// <returns>url参数</returns>
        public static string GroupPayParam(Dictionary<string, string> Dt_PayParam)
        {
            StringBuilder StrParam = new StringBuilder();
            foreach (KeyValuePair<string,string> KeyValu in Dt_PayParam)
            {
                StrParam.Append("&").Append(KeyValu.Key).Append("=").Append(KeyValu.Value);
            }
            return StrParam.ToString().Substring(1);
        }
        #endregion
    }
}
