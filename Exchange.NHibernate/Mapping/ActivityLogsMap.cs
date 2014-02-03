using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class ActivityLogsMap : ClassMap<ActivityLogs>
    {
        public ActivityLogsMap()
        {
            Table("ActivityLogs");
            Id(x => x.Id);
            Map(x => x.Type);
            Map(x => x.Description);
            Map(x => x.ExecutedBy);
            Map(x => x.Timestamp);

        }


    }
}
