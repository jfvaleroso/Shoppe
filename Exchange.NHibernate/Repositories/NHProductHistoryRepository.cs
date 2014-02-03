using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHProductHistoryRepository : NHRepositoryBase<ProductHistory, long>, IProductHistoryRepository
    {
        public List<ProductHistory> GetDataWithPagingAndSearch(string id, int pagNumber, int pageSize, out long total)
        {
            return this.GetDataWithPagingAndSearch(ProductHistoryFilter.Search(id), ProductHistoryFilter.Alias(), ProductHistoryFilter.Orders(), pagNumber, pageSize, out total);
        }
    }
}
