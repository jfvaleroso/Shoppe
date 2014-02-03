using Exchange.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Mapping
{
    public class ProductHistoryMap : ClassMap<ProductHistory>
    {
        public ProductHistoryMap()
        {
            Table("ProductHistory");
            Id(x => x.Id);
            Map(x => x.Cost);
            References(x => x.Product, "Product_Id");
            Map(x => x.DateModified);
            Map(x => x.ModifiedBy);

        }
    }
}
