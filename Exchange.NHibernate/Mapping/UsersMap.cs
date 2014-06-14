using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class UsersMap : ClassMap<Users>
    {
        public UsersMap()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.Username);
            Map(x => x.ApplicationName);
            Map(x => x.Email);
            Map(x => x.Comment);
            Map(x => x.Password);
            Map(x => x.PasswordQuestion);
            Map(x => x.PasswordAnswer);
            Map(x => x.IsApproved);
            Map(x => x.LastActivityDate);
            Map(x => x.LastLoginDate);
            Map(x => x.LastPasswordChangedDate);
            Map(x => x.CreationDate);
            Map(x => x.IsOnLine);
            Map(x => x.IsLockedOut);
            Map(x => x.LastLockedOutDate);
            Map(x => x.FailedPasswordAttemptCount);
            Map(x => x.FailedPasswordAnswerAttemptCount);
            Map(x => x.FailedPasswordAttemptWindowStart);
            Map(x => x.FailedPasswordAnswerAttemptWindowStart);
            HasManyToMany(x => x.Roles)
                .Cascade.All()
                .Table("UsersInRoles");
            HasManyToMany(x => x.Stores)
                .Cascade.All()
                .Table("UsersInStore");

            //HasManyToMany(x => x.Roles)
            //        .Cascade.All()
            //        .Table("UsersInRoles");

            //HasManyToMany(x => x.Stores)
            //       .Cascade.All()
            //       .Table("UsersInStore");
        }
    }
}