using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace mvc_1.Util
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NeedAuthorizeAttribute : ActionFilterAttribute
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session["User"] == null)
            {
                if (ConfigurationManager.AppSettings["SSO"] != null)
                {
                    DotNet.Utilities.UserConfigHelper.LogOnTo = ConfigurationManager.AppSettings["SSO"];
                    string url = HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString());
                    url = DotNet.Utilities.UserConfigHelper.LogOnTo + "?ReturnUrl=" + url;
                    filterContext.HttpContext.Response.Redirect(url, true);
                }
                else
                {
                    filterContext.Result=new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new {Controller=""}));
                }

            }
        }
    }
}