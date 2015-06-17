using System;

namespace SSO
{
    public class Voucher
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 凭证
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public DateTime ValidTime { get; set; }
    }
}