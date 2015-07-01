using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using Elf;

namespace SSO
{
    /// <summary>
    /// database 的摘要说明
    /// </summary>
    public class database : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var jss = new JavaScriptSerializer();
            var dbs = Getdbs();
            jss.MaxJsonLength = 20971520;
            context.Response.Write(jss.Serialize(dbs));
           
        }

        private static IList<DataBase> Getdbs()
        {
            var dbs =Iris.GetDataBases();
            return dbs;
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