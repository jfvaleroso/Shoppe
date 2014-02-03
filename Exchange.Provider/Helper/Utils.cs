using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Provider.Helper
{
   public static class Utils
    {
       public static DateTime MinDate()
       {
           return System.Convert.ToDateTime("01/01/1753");

       }
    }
}
