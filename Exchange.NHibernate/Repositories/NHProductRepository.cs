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
    public class NHProductRepository : NHRepositoryBase<Product, int>, IProductRepository
    {
        public List<Product> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return this.GetDataWithPagingAndSearch(ProductFilter.Search(searchString), searchString, pageIndex, pageSize, out total);
        }
    }
}
