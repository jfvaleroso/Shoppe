using System;

namespace Exchange.Core.Entities
{
    public class ActivityLogs : Entity<Guid>
    {
        public ActivityLogs()
        {
            Timestamp = DateTime.Now;
        }

        public virtual string Type { get; set; }

        public virtual string Description { get; set; }

        public virtual string ExecutedBy { get; set; }

        public virtual DateTime Timestamp { get; set; }
    }
}