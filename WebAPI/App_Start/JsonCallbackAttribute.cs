using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace WebAPI
{
    public class JsonCallbackAttribute:ActionFilterAttribute
    {
        private const string CallbackQueryParameter = "callback";

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
           var jsonBuilder=new StringBuilder(null);
                jsonBuilder.AppendFormat("({0})'", context.Response.Content.ReadAsStringAsync().Result);
                context.Response.Content = new StringContent(jsonBuilder.ToString());
                base.OnActionExecuted(context);
        }
    }
}