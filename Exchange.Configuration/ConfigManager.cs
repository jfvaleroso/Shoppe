using System.Web.Configuration;

namespace Exchange.Configuration
{
    public static class ConfigManager
    {
        private static ExchangeConfig _config;

        public static ExchangeConfig Exchange
        {
            get
            {
                if (_config == null)
                {
                    _config = ExchangeConfig.Section;
                }
                return _config;
            }
            set { _config = value; }
        }

        public static System.Configuration.Configuration GetConfig()
        {
            return WebConfigurationManager.OpenWebConfiguration("~/config");
        }

        public static ExchangeConfig GetSection(System.Configuration.Configuration config)
        {
            return (config.GetSection("exchange") as ExchangeConfig);
        }
    }
}