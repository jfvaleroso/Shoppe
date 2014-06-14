using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class SecurityCodeMap : ClassMap<SecurityCode>
    {
        public SecurityCodeMap()
        {
            Table("SecurityCode");
            Id(x => x.Id);
            Map(x => x.PassCode);
            Map(x => x.DateCreated);
            Map(x => x.DateUsed);
            Map(x => x.UsedBy);
            Map(x => x.IsUsed);
            Map(x => x.Bonus);
        }
    }
}