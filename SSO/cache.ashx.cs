﻿using System;
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
            var vouchers = CacheManager.GetCacheList();
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