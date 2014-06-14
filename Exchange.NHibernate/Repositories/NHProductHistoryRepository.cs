using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHProductHistoryRepository : NHRepositoryBase<ProductHistory, Guid>, IProductHistoryRepository
    {
        public List<ProductHistory> GetDataWithPagingAndSearch(string id, int pagNumber, int pageSize, out long total)
        {
            return GetDataWithPagingAndSearch(ProductHistoryFilter.Search(id), ProductHistoryFilter.Alias(),
                ProductHistoryFilter.Orders(), pagNumber, pageSize, out total);
        }
    }
}