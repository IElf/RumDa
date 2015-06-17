using System;
using System.Collections.Generic;
using System.Web.UI;

namespace SSO
{
    public partial class CacheList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IList<Voucher> vouchers = CacheManager.GetCacheList();
                if (vouchers != null)
                {

                }
            }
        }
    }
}