using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using NHibernate.Criterion;
using Exchange.Helper;
using Exchange.Helper.Common;
using Exchange.NHibernateBase.Filters;


namespace Exchange.NHibernateBase.Repositories
{
    public class NHProductTypeRepository : NHRepositoryBase<ProductType, int>, IProductTypeRepository
    {
        public List<ProductType> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {

            return this.GetDataWithPagingAndSearch(ProductTypeFilter.Search(searchString), searchString, pageIndex, pageSize, out total);
        }


      
    }
}
