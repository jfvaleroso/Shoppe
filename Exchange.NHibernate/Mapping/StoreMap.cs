using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Exchange.Core.Entities;

namespace Exchange.NHibernateBase.Mapping
{
    public class StoreMap: ClassMap<Store>
    {
        public StoreMap()
        {
            Table("Store");
            Id(x => x.Id);
            Map(x => x.Code);
            Map(x => x.Name);
            Map(x => x.Address);
            Map(x => x.TelephoneNo);
            Map(x => x.PermitNo);
            Map(x => x.TINNo);
            Map(x => x.Active);
            Map(x => x.CreatedBy);
            Map(x => x.DateCreated);
            Map(x => x.ModifiedBy);
            Map(x => x.DateModified);
            HasManyToMany(x => x.UsersInStore)
           .Cascade.All()
           .Table("UsersInStore");

        }

       
    }
}
