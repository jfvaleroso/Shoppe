using Exchange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Repositories
{
    public interface IProductHistoryRepository : IRepository<ProductHistory, Guid>, ISearchRepository<ProductHistory>
    {
    }
}
