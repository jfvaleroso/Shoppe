using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Exchange.Helper;
using System.Globalization;
using Exchange.Helper.Common;

namespace Exchange.Web.Helper
{
    public class CryptoProvider : IValueProvider
    {
        RouteData routeData = null;
        object data;
        public CryptoProvider(RouteData routeData)
        {
            this.routeData = routeData;
        }
        public bool ContainsPrefix(string prefix)
        {
            if (this.routeData.Values["id"] == null)
            {
                return false;
            }
            data = Base.Decrypt(this.routeData.Values["id"].ToString());
            return true;
        }
        public ValueProviderResult GetValue(string key)
        {
            ValueProviderResult result;
            result = new ValueProviderResult(data,
                "Id", CultureInfo.CurrentCulture);
            return result;
        }
    }
}