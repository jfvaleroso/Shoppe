using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHStoreRepository : NHRepositoryBase<Store, Guid>, IStoreRepository
    {
        public List<Store> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return GetDataWithPagingAndSearch(StoreFilter.Search(searchString), StoreFilter.Alias(),
                StoreFilter.Orders(), pageIndex, pageSize, out total);
        }
    }
}