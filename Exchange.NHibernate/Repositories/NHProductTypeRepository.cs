using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHProductTypeRepository : NHRepositoryBase<ProductType, Guid>, IProductTypeRepository
    {
        public List<ProductType> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize,
            out long total)
        {
            return GetDataWithPagingAndSearch(ProductTypeFilter.Search(searchString), searchString, pageIndex, pageSize,
                out total);
        }
    }
}