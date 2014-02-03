using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exchange.Core.Entities;

namespace Exchange.Web.Models
{
    public class JsonResponse
    {
        public string Result { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string CSSClass { get;set; }
        public bool Saved { get; set; }
        public bool Modified { get; set; }
        public bool Deleted { get; set; }
        public bool Exists { get; set; }
        public List<JsonResponseItem> Messages { get; set; }

        


      
      

    }
}