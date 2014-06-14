using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHCustomerRepository : NHRepositoryBase<Customer, Guid>, ICustomerRepository
    {
        public List<Customer> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize,
            out long total)
        {
            return GetDataWithPagingAndSearch(CustomerFilter.Search(searchString), CustomerFilter.Alias(),
                CustomerFilter.Orders(), pageIndex, pageSize, out total);
        }
    }
}