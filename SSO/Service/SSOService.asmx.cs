using System.Linq;
using System.Web.Services;

namespace SSO.Service
{
    /// <summary>
    /// SSOService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SSOService : WebService
    {
        /// <summary>
        /// 根据token 获取用户凭证
        /// </summary>
        /// <param name="token">令牌</param>
        /// <returns>object</returns>
        [WebMethod]
        public object GetVoucher(string token)
        {
            object cert = null;
            var vouchers = CacheManager.GetCacheList();
            if (vouchers != null)
            {
                var voucher = vouchers.FirstOrDefault(x => x.Token == token);
                if (voucher != null)
                {
                    cert = voucher.Id;
                }
            }
            return cert;
        }
        /// <summary>
        /// 清除令牌
        /// </summary>
        /// <param name="token">令牌</param>
        [WebMethod]
        public void TokenClear(string token)
        {
            var vouchers = CacheManager.GetCacheList();
            if (vouchers != null)
            {
                var voucher = vouchers.FirstOrDefault(x => x.Token == token);
                if (voucher != null)
                {
                    vouchers.Remove(voucher);
                }
            }
        }
    }
}
