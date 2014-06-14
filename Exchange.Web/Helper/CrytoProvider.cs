using Exchange.Helper.Common;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Routing;

namespace Exchange.Web.Helper
{
    public class CryptoProvider : IValueProvider
    {
        private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>();
        private readonly RouteData routeData;

        public CryptoProvider(RouteData routeData)
        {
            routeData = routeData;
        }

        public bool ContainsPrefix(string prefix)
        {
            object data = routeData.Values[prefix];
            if (data == null)
            {
                return false;
            }
            dictionary.Add(prefix, Base.Decrypt(data.ToString()));
            return dictionary.ContainsKey(prefix);
        }

        public ValueProviderResult GetValue(string key)
        {
            ValueProviderResult result = null;
            if (dictionary.ContainsKey(key))
            {
                result = new ValueProviderResult(dictionary[key],
                    dictionary[key], CultureInfo.CurrentCulture);
            }

            return result;
        }
    }
}