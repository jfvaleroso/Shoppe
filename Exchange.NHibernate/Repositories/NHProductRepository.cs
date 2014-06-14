using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHProductRepository : NHRepositoryBase<Product, Guid>, IProductRepository
    {
        public List<Product> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return GetDataWithPagingAndSearch(ProductFilter.Search(searchString), searchString, pageIndex, pageSize,
                out total);
        }

        public List<Product> Test()
        {
            return Test(ProductFilter.Test(), ProductFilter.AliasTest(), ProductFilter.OrdersTest());
        }
    }
}