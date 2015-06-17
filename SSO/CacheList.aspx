<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CacheList.aspx.cs" Inherits="SSO.CacheList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" ng-app="cache">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body ng-controller="CackeGet">
    <form id="form1" runat="server">
        <div style="width: 900px;">
            <div style="float: left; width: 880px; font-size: 18px; font-weight: bold; padding: 10px; background-color: #006ebe; color: white; text-align: center;">
                欢迎来到www.sso.com服务器
            </div>
            <div style="float: left; width: 100%; height: 30px; margin-top: 20px; margin-bottom: 20px;">
                <div style="float: left; width: 100px;"><a href="UserLogin.aspx?backurl=<%= Request.QueryString["backurl"] != null ? Request.QueryString["backurl"].ToString() : "" %>">用户登录</a></div>
                <div style="float: left; width: 100px; font-weight: bold;">查看缓存</div>
            </div>
            <div>
                <ul>
                    <li ng-repeat="item in list">
                        <ul>
                            <li ng-bind="item.Id"></li>
                            <li ng-bind="item.Token"></li>
                            <li ng-bind="item.ValidTime"></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
<script src="Js/angular.js"></script>
<script src="Js/angular-resource.js"></script>
<script src="Js/tokenCtrl.js"></script>
