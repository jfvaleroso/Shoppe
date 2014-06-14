using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Repositories
{
    public interface IProductHistoryRepository : IRepository<ProductHistory, Guid>, ISearchRepository<ProductHistory>
    {
    }
}