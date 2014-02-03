using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Exchange.Core.Entities;

namespace Exchange.NHibernateBase.Mapping
{
    public class SecurityCodeMap: ClassMap<SecurityCode>
    {
        public SecurityCodeMap()
        {

            Table("SecurityMap");
            Id(x => x.Id);
            Map(x => x.PassCode);
            Map(x => x.DateCreated);
            Map(x => x.UsedBy);
            Map(x => x.Status);
            


        }
    }
}
