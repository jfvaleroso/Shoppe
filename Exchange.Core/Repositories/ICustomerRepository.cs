using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, Guid>, ISearchRepository<Customer>
    {
    }
}