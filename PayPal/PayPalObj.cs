using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayPal
{
    //https://developer.paypal.com/docs/classic/api/currency_codes/?mark=currency
    #region PayPal支付参数对象
    /// <summary>
    /// Create By Asen
    /// 2016-08-04
    /// </summary>
    #endregion
    public class PayPalObj
    {
        /// <summary>
        /// 订单名称
        /// </summary>
        public string item_name;
        /// <summary>
        /// 物品数量
        /// </summary>
        public string quantity;
        /// <summary>
        /// 支付金额
        /// </summary>
        public string amount;
        /// <summary>
        /// 币种
        /// </summary>
        public string currency_code;
        /// <summary>
        /// 支付成功用户跳转的页面
        /// </summary>
        public string return_url;
        /// <summary>
        /// 支付成功异步回调页面
        /// </summary>
        public string notify_url;
        /// <summary>
        /// 取消支付用户跳转的页面
        /// </summary>
        public string cancel_return;
        /// <summary>
        /// 卖家账户
        /// </summary>
        public string business;
        /// <summary>
        /// 编码方式
        /// </summary>
        public string charset="utf-8";
        /// <summary>
        /// 提交按钮方式（必须有）
        /// </summary>
        public string cmd = "_xclick";
    }
}
