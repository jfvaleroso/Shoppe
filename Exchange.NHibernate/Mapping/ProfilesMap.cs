using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class ProfilesMap : ClassMap<Profiles>
    {
        public ProfilesMap()
        {
            Table("Profiles");
            Id(x => x.Id);
            Map(x => x.UserId).Column("Users_Id");
            Map(x => x.ApplicationName);
            Map(x => x.LastActivityDate);
            Map(x => x.LastUpdatedDate);
            Map(x => x.Subscription);
            Map(x => x.Language);
            Map(x => x.MiddleName);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Gender);
            Map(x => x.IsAnonymous);
            Map(x => x.Position);
            Map(x => x.Address);
            Map(x => x.BirthDate);
        }
    }
}