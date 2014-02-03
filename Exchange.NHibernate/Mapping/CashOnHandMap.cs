using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class CashOnHandMap: ClassMap<CashOnHand>
    {
        public CashOnHandMap()
        {
            Table("CashOnHand");
            Id(x => x.Id);
            Map(x => x.Cash);
            Map(x => x.Note);
            Map(x => x.DateReceived);
            Map(x => x.ReceivedBy);
            Map(x => x.DateCreated);
            Map(x => x.DateModified);
            Map(x => x.ModifiedBy);
            Map(x => x.StoreId).Column("Store_Id");

        }
    }
}
