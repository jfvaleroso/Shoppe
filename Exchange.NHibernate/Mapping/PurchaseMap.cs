using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class PurchaseMap: ClassMap<Purchase>
    {
        public PurchaseMap ()
        {
            Table("Purchase");
            Id(x => x.Id);
            Map(x => x.ProductCode);
            Map(x => x.Grams);
            Map(x => x.Quantity);
            Map(x => x.Description);
            Map(x => x.Cost);
            Map(x => x.Bonus);
            Map(x => x.Total);
            Map(x => x.Rate);
            Map(x => x.DateCreated);
            Map(x => x.Cashier);
            Map(x => x.InvoiceId).Column("Invoice_Id");
            Map(x => x.Appraiser);
            Map(x => x.CustomerId).Column("Customer_Id");
            Map(x => x.Status);




	}
        
    }
}
