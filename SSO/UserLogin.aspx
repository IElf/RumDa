<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="SSO.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link type="text/css" rel="stylesheet/less" href="Css/LESS.less" />
    <script src="Js/less.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <div style="width: 350px; margin: 0 auto;">
                    <div class="left">
                        <p>User ID</p>
                        <p>
                            <input type="text" id="userId" />
                        </p>
                    </div>
                    <div class="left">
                        <p>Password</p>
                        <input type="password" id="password" />
                    </div>
                    <div>
                        <input type="button" value="Sign In" ng-click="Login" />
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
