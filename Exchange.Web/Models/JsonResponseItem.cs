using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exchange.Web.Models
{
    public class JsonResponseItem
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public string CSSClass { get; set; }
    }
}