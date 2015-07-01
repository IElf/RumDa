<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBases.aspx.cs" Inherits="SSO.DataBases" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" ng-app="cache">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link type="text/css" rel="stylesheet/less" href="Css/LESS.less" />
    <script src="Js/less.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/waterfall.css" />
    <link rel="stylesheet" href="css/test.css" />
    <title>p</title>
    <style>
        body {
            color: #58595B;
            line-height: 1.2em;
            font-weight: bold;
            font-family: Bitter, Cambria, Georgia, serif;
        }
    </style>
</head>
<body ng-controller="CackeGet">
    <form id="form1" runat="server">
        <section id="wrapper">
            <div id="container">
                    <div class="grid doudong doudongxg" ng-repeat="item in list">
                        <div style="background: url(images/sql.gif) no-repeat; padding-left: 40px; text-align: left; height: 40px;">
                            <strong ng-bind="item.BaseName">这里是名称</strong>
                        </div>
                        <div class="meta" ng-bind="item.FileName">文件地址</div>
                    </div>
            </div>
        </section>
    </form>
</body>
</html>
<script src="Js/angular.js"></script>
<script src="Js/angular-resource.js"></script>
<script src="Js/baseCtrl.js"></script>
<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="js/stellar.js"></script>
<script type="text/javascript" src="js/jquery.sticky.js"></script>
<script type="text/javascript" src="js/custom.js"></script>
<script type="text/javascript" src="js/jquery.validate.min.js"></script>
<script type="text/javascript" src="js/blocksit.min.js"></script>
<script type="text/javascript" src="js/type.js"></script>
