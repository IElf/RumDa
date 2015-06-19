using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

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
            var jss = new JavaScriptSerializer();
            context.Response.Write(jss.Serialize(GetVouchers()));
        }

        private static IList<Voucher> GetVouchers()
        {

             var vouchers =CacheManager.GetCacheList();
            //var vouchers = new List<Voucher>();
            //for (int i = 0; i < 5; i++)
            //{
            //    vouchers.Add(new Voucher
            //   {
            //       Token = Guid.NewGuid().ToString(),
            //       Id = Guid.NewGuid().GetHashCode(),
            //       ValidTime = DateTime.Now.AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss")
            //   });
            //}
            return vouchers;

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