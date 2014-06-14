using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase, Guid>, ISearchRepository<Purchase>
    {
    }
}