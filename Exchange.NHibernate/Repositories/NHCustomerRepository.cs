using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using NHibernate.Criterion;
using Exchange.Helper;
using Exchange.NHibernateBase.Filters;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHCustomerRepository : NHRepositoryBase<Customer, long>, ICustomerRepository
    {
        public List<Customer> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return this.GetDataWithPagingAndSearch(CustomerFilter.Search(searchString), CustomerFilter.Alias(), CustomerFilter.Orders(), pageIndex, pageSize, out total);
        }
    }
}
