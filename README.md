# PayPal
#### 实现功能：
1. 使用PayPal标准集成API从后台发起支付请求,并非从from表单中提交,提升了安全性。
2. 实现了IPN消息验证函数。

---

### 如何使用：

**使用对象方式调用：**

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
       custom="用于IPN回传用户自定义的参数",
       charset = "编码格式"
  });
```
使用对象方式只支持以上参数,如果需要更多参数,请使用自定义参数方式调用。

**自定义参数方式调用：**

```
 Dictionary<string, string> Dt_Parames = new Dictionary<string, string>();
 /*添加自定义参数：*/
 Dt_Prame.Add("business", "293123@qq.com");
 Dt_Prame.Add("quantity", "10");
 ....

 Pay PayPal=new Pay("PayPal沙盒测试地址或正式地址");
 PayPal.PostPay(Dt_Parames);
```
---

#### 使用注意：
IPN验证以及支付请求如果出现建立SSL/TSL通道失败的异常,请使用以下方式解决问题：

1. 安装.net 版本4.5。

2. 使用已下代码,该代码使用的.net版本最低也要4.0,而且不一定会成功。

```
System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
```
---

#### 此项目沙盒测试账号(只能测试)：
1. 商户账户：AsenB@qq.com 
2. 客户账号：Asen@qq.com 密码：12345678

---

#### 沙盒账号申请地址
[沙盒地址](https://developer.paypal.com/)

---

#### PayPal参数列表
1. [支付参数列表](https://www.paypal-biz.com/product/pdf/PayPal_WPS_Guide_CN_V2.0.pdf)
2. [IPN消息列表](https://www.paypal-biz.com/product/pdf/PayPal_IPN&PDT_Guide_V1.0.pdf])
3. [Pay支付的货币码列表](https://developer.paypal.com/docs/classic/api/currency_codes/?mark=currency)




