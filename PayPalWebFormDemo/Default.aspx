<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PayPalWebFormDemo.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>PayPal参数设置</title>
    <style type="text/css">
        .tb{ width:350px;}
    </style>
</head>
<body>
<h3>PayPal支付Demo</h3>
<form action="PostRequest.aspx" method="post">
    <div>提交订单地址（沙盒地址或者正式地址）：<input class="tb" type="text" name="url" value="https://www.sandbox.paypal.com/cgi-bin/webscr" /> </div><br/>
    <div>卖家邮箱：<input type="text" class="tb" name="business" value="AsenB@qq.com" /> </div><br/>
    <div>订单名称：<input type="text" class="tb" name="item_name" value="测试订单" /> </div><br/>
    <div>数量：<input type="text" class="tb" name="quantity" value="1" /> </div><br/>
    <div>订单金额：<input type="text" class="tb" name="amount" value="0.01" /> </div><br/>
    <div>货币种类：<input type="text" class="tb" name="currency_code" value="HKD" /> </div><br/>
    <div>支付成功跳转地址：<input class="tb" type="text" name="return" value="http://my-mall.cn/Index" /> </div><br/>
    <div>支付成功异步回调地址：<input class="tb" type="text" name="notify_url" value="http://my-mall.cn/Index" /> </div><br/>
    <div>取消支付跳转地址：<input class="tb" type="text" name="cancel_return" value="http://my-mall.cn/Index" /> </div><br/>
    <div>编码方式：<input class="tb" type="text" name="charset" value="utf-8" /> </div><br/>
    <input type="submit" value="提交订单" />
</form>
</body>
</html>
