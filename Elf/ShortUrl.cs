using System.Linq;
using System.Text.RegularExpressions;

namespace Elf
{
    /// <summary>
    /// url to short 
    /// </summary>
    public class ShortUrl
    {
        /// <summary>
        /// url 
        /// </summary>
        public string Url { get; set; }

        public ShortUrl(string url)
        {
            Url = url;
        }
        public ShortUrl()
            : this(null)
        {
        }
        /// <summary>
        /// get param hash
        /// </summary>
        public int ParamHash
        {
            get
            {
                if (UrlCheck)
                {
                    return Url.Split('?')[1].Split('&').Select(s => s.GetHashCode()).Aggregate(0, (x, y) => x ^ y);
                }
                return 0;
            }
        }
        /// <summary>
        /// short address
        /// </summary>
        public string Shortener
        {
            get
            {
                if (UrlCheck)
                {
                    return Url.Split('?')[0] + "?" + UrlHash;
                }
                return "";
            }

        }
        /// <summary>
        /// url hash
        /// </summary>
        public int UrlHash
        {
            get
            {
                if (UrlCheck)
                    return Url.Split('?')[1].Split('&').Select(s => s.GetHashCode()).Aggregate(Url.Split('?')[0].GetHashCode(), (x, y) => x ^ y);
                return 0;
            }
        }
        /// <summary>
        /// url Check 
        /// </summary>
        public bool UrlCheck
        {
            get
            {
                var Pattern = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&$%\$#\=~])*$";
                var r = new Regex(Pattern);
                var m = r.Match(Url);
                return m.Success; 
            }
        }
    }
}
