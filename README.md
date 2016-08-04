# PayPal
实现了PayPal从后台发起支付请求,并非从from表单中提交,提升了安全性。
---
#### 如何使用
1. **使用对象方式调用：**
```
Pay PayPal = new Pay("PayPal沙盒测试地址或正式地址");

PayPal.PostPay(new PayPalObj()
   {
       business = "卖家邮箱",
       item_name ="商品名称",
       quantity = "数量",
       amount = "金额",
       currency_code = "货币",
       return_url = "支付成功跳转地址",
       notify_url = "支付成功的异步回调地址",
       cancel_return = "用户取消支付跳转地址",
       charset = "编码格式"
  });
```
2. **自定义参数方式调用**
```
 Dictionary<string, string> Dt_Parames = new Dictionary<string, string>();
 /*添加自定义参数：*/
 Dt_Prame.Add("business", "293123@qq.com");
 Dt_Prame.Add("quantity", "10");
 ....

 Pay PayPal=new Pay("PayPal沙盒测试地址或正式地址");
 PayPal.PostPay(Dt_Parames);
```

#### PayPal参数列表
1. (支付参数列表)[https://www.paypal-biz.com/product/pdf/PayPal_WPS_Guide_CN_V2.0.pdf]
2. (回调参数列表)[https://www.paypal-biz.com/product/pdf/PayPal_IPN&PDT_Guide_V1.0.pdf]
3. (Pay支付的货币码列表)[https://developer.paypal.com/docs/classic/api/currency_codes/?mark=currency]




