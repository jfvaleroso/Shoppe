using System;

namespace Exchange.Web.Models
{
    public class AuditModel
    {
        public Guid AuditID { get; set; }

        public string UserName { get; set; }

        public string IPAddress { get; set; }

        public string AreaAccessed { get; set; }

        public DateTime TimeAccessed { get; set; }

        public string Action { get; set; }

        public string Result { get; set; }
    }
}