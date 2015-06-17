using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSO
{
    /// <summary>
    /// cache 的摘要说明
    /// </summary>
    public class cache : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}