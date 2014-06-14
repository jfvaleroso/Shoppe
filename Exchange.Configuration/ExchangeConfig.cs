using System.Configuration;
using System.Web.Configuration;

namespace Exchange.Configuration
{
    public class ExchangeConfig : ConfigurationSection
    {
        public static ExchangeConfig Section
        {
            get
            {
                object section = WebConfigurationManager.GetSection("exchange", "~/config");
                if (section != null)
                {
                    return (section as ExchangeConfig);
                }
                return null;
            }
        }

        [ConfigurationProperty("companyName", DefaultValue = "", IsRequired = false)]
        public string CompanyName
        {
            get { return (string)base["companyName"]; }
            set { base["companyName"] = value; }
        }

        [ConfigurationProperty("owner", DefaultValue = "", IsRequired = false)]
        public string Owner
        {
            get { return (string)base["owner"]; }
            set { base["owner"] = value; }
        }

        [ConfigurationProperty("applicationName", DefaultValue = "", IsRequired = false)]
        public string ApplicationName
        {
            get { return (string)base["applicationName"]; }
            set { base["applicationName"] = value; }
        }
    }
}