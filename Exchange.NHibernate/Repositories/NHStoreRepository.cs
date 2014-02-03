using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Exchange.Core.Repositories;
using Exchange.Core.Entities;
using NHibernate.Criterion;
using Exchange.Helper;
using Exchange.Helper.Common;
using Exchange.NHibernateBase.Filters;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHStoreRepository : NHRepositoryBase<Store, int>, IStoreRepository
    {
        public List<Store> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return this.GetDataWithPagingAndSearch(StoreFilter.Search(searchString), StoreFilter.Alias(), StoreFilter.Orders(), pageIndex, pageSize, out total);
        }
    }
}
