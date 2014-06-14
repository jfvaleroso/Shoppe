using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Exchange.Helper.Common
{
    public class Settings
    {
        public static bool EnableInitialization
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["Exchange:EnableInitialization"]);
            }
          
        }
    }
}
