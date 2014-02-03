using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class InvoiceMap : ClassMap<Invoice>
    {
        public InvoiceMap()
        {
            Table("Invoice");
            Id(x => x.Id);
            Map(x => x.TransactionCode);
            Map(x => x.Amount);
            Map(x => x.DateIssued);
            Map(x => x.Cashier);
            Map(x => x.Appraiser);
            References(x => x.Customer);
            References(x => x.Status);
            References(x => x.Store);

        }

    }
}
