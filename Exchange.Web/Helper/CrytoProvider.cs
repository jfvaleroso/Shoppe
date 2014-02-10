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
        Dictionary<string, string> dictionary = new Dictionary<string,string>();

        public CryptoProvider(RouteData routeData)
        {
            this.routeData = routeData;
        }

        public bool ContainsPrefix(string prefix)
        {
            var data = this.routeData.Values[prefix];
            if (data == null)
            {
                return false;
            }
            else
            {
                this.dictionary.Add(prefix, Base.Decrypt(data.ToString()));
            }
            return this.dictionary.ContainsKey(prefix);
        }

        public ValueProviderResult GetValue(string key)
        {
            ValueProviderResult result=null;
            if (this.dictionary.ContainsKey(key))
            {
                result = new ValueProviderResult(this.dictionary[key],
                this.dictionary[key], CultureInfo.CurrentCulture);
            }
                   
            return result;
        }
    }
}