using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class PurchaseMap : ClassMap<Purchase>
    {
        public PurchaseMap()
        {
            Table("Purchase");
            Id(x => x.Id);

            Map(x => x.Quantity);
            Map(x => x.Grams);
            Map(x => x.Rate);
            Map(x => x.Cost);
            Map(x => x.Bonus);
            Map(x => x.Total);
            Map(x => x.Description);

            Map(x => x.DateCreated);
            Map(x => x.DateModified);
            Map(x => x.CreatedBy);
            Map(x => x.ModifiedBy);

            References(x => x.Invoice, "Invoice_Id");
            References(x => x.Product, "Product_Id");
            References(x => x.SecurityCode, "SecurityCode_Id");
        }
    }
}