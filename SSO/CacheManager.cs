using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SSO
{
    /// <summary>
    /// 缓存管理
    /// 将令牌、用户凭证以及过期时间的关系数据存放于Cache中
    /// </summary>
    public static class CacheManager
    {
        /// <summary>
        /// 初始化缓存数据结构
        /// </summary>
        /// <remarks>
        /// ----------------------------------------------------
        /// | Token(令牌) | Id(用户凭证) | ValidTime(过期时间) |
        /// |--------------------------------------------------|
        /// </remarks>
        private static void CacheInit()
        {
            if (HttpContext.Current.Cache["SSO.TOKEN"] == null)
            {
                IList<Voucher> voucher = new List<Voucher>();

                voucher.Add(new Voucher
                {
                    Id = Guid.NewGuid().GetHashCode(),
                    Token = "",
                    ValidTime = DateTime.Now.AddMinutes(double.Parse(ConfigurationManager.AppSettings["Timeout"])).ToString("yyyy-MM-dd HH:mm:ss")
                });
                //Cache的过期时间为 令牌过期时间*2
                HttpContext.Current.Cache.Insert("SSO.TOKEN", voucher, null, DateTime.MaxValue, TimeSpan.FromMinutes(double.Parse(ConfigurationManager.AppSettings["Timeout"]) * 2));
            }
        }

        /// <summary>
        /// 获取缓存中的List
        /// </summary>
        /// <returns></returns>
        public static IList<Voucher> GetCacheList()
        {
            IList<Voucher> vouchers = new List<Voucher>();
            if (HttpContext.Current.Cache["SSO.TOKEN"] != null)
            {
                vouchers = (List<Voucher>)HttpContext.Current.Cache["SSO.TOKEN"];
            }
            return vouchers;
        }

        /// <summary>
        /// 判断令牌是否存在
        /// </summary>
        /// <param name="token">令牌</param>
        /// <returns></returns>
        public static bool TokenIsExist(string token)
        {
            CacheInit();
            IList<Voucher> vouchers = (List<Voucher>)HttpContext.Current.Cache["SSO.TOKEN"];
            return vouchers.Any(x => x.Token == token);
        }

        /// <summary>
        /// 更新令牌过期时间
        /// </summary>
        /// <param name="token">令牌</param>
        /// <param name="time">过期时间</param>
        public static void TokenTimeUpdate(string token, DateTime time)
        {
            CacheInit();
            IList<Voucher> vouchers = (List<Voucher>)HttpContext.Current.Cache["SSO.TOKEN"];
            var voucher = vouchers.FirstOrDefault(x => x.Token == token);
            if (voucher != null)
            {
                voucher.ValidTime = time.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 添加令牌
        /// </summary>
        /// <param name="token">令牌</param>
        /// <param name="cert">凭证</param>
        /// <param name="validtime">过期时间</param>
        public static void TokenAdd(string token, object cert, DateTime validtime)
        {
            CacheInit();
            //token不存在则添加
            if (!TokenIsExist(token))
            {
                IList<Voucher> vouchers = (List<Voucher>)HttpContext.Current.Cache["SSO.TOKEN"];
                vouchers.Add(new Voucher()
                {
                    Id = cert.GetHashCode(),
                    Token = token,
                    ValidTime = validtime.ToString("yyyy-MM-dd HH:mm:ss")
                });
                HttpContext.Current.Cache["SSO.TOKEN"] = vouchers;
            }
            //token存在则更新过期时间
            else
            {
                TokenTimeUpdate(token, validtime);
            }
        }

    }//end class
}