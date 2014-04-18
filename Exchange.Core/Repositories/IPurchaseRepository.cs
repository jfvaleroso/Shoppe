using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;

namespace Exchange.Core.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase, Guid>, ISearchRepository<Purchase>
    {
      
       
    }
}
