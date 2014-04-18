using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public class ActivityLogs : Entity<Guid>
    {
        public virtual string Type { get; set; }
        public virtual string Description { get; set; }
        public virtual string ExecutedBy { get; set; }
        public virtual DateTime Timestamp { get; set; }

        public ActivityLogs()
        {
            this.Timestamp = DateTime.Now;
        }
    }
}
