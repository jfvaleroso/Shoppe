using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Id(x => x.Id);
            Map(x => x.Name).Length(300).Nullable();
            Map(x => x.Code).Length(300).Nullable();
            Map(x => x.Description).Length(300).Nullable();
            Map(x => x.Cost).Nullable();
            Map(x => x.CreatedBy).Length(300).Nullable();
            Map(x => x.DateCreated).Nullable();
            Map(x => x.ModifiedBy).Length(300).Nullable();
            Map(x => x.DateModified).Nullable();
            Map(x => x.Active);
            References(x => x.ProductType, "ProductType_Id");
            HasMany(x => x.ProductHistories)
                .Inverse()
                .Cascade.All();
        }
    }
}