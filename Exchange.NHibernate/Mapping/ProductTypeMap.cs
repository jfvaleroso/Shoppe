using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Exchange.Core.Entities;

namespace Exchange.NHibernateBase.Mapping
{
    public class ProductTypeMap : ClassMap<ProductType>
    {
        public ProductTypeMap()
        {
            Table("ProductType");
            Id(x => x.Id);
            Map(x => x.Code);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Active);
            Map(x => x.DateCreated);
            Map(x => x.CreatedBy);
            Map(x => x.DateModified);
            Map(x => x.ModifiedBy);
            HasMany(x => x.Products)
                .Inverse()
                .Cascade.All();



        }
    }
}
