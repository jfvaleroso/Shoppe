using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class RoleMap : ClassMap<Roles>
    {
        public RoleMap()
        {
            Table("Roles");
            Id(x => x.Id);
            Map(x => x.RoleName);
            Map(x => x.ApplicationName);
            Map(x => x.Description);
            HasManyToMany(x => x.UsersInRole)
                .Cascade.All()
                .Inverse()
                .Table("UsersInRoles");
        }
    }
}