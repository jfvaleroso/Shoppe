﻿using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class InvoiceMap : ClassMap<Invoice>
    {
        public InvoiceMap()
        {
            Table("Invoice");
            Id(x => x.Id);
            Map(x => x.InvoiceNo);
            Map(x => x.SubTotal);
            Map(x => x.TotalBonus);
            Map(x => x.GrandTotal);

            References(x => x.Cashier, "Cashier_Id");
            References(x => x.Appraiser, "Appraiser_Id");
            References(x => x.Customer, "Customer_Id");
            References(x => x.Status, "Status_Id");
            References(x => x.Store, "Store_Id");

            Map(x => x.DateIssued);
            Map(x => x.DateModified);
            Map(x => x.DateCreated);

            HasMany(x => x.Purchases)
                .Inverse()
                .Cascade.All();

            HasMany(x => x.Notes)
                .Inverse()
                .Cascade.All();
        }
    }
}