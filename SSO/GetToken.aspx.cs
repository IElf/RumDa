using System;
using System.Web;
using System.Web.UI;
namespace SSO
{
    public partial class GetToken : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["backurl"] != null)
            {
                string backURL = Server.UrlDecode(Request.QueryString["backurl"]);

                //获取Cookie
                HttpCookie token = Request.Cookies["Passport.Token"];
                if (token != null)
                {
                    backURL = backURL.Replace("$token$", token.Values["Value"]);
                }
                Response.Redirect(backURL);
            }
        }
    }
}