using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHPurchaseRepository : NHRepositoryBase<Purchase, Guid>, IPurchaseRepository
    {
        public List<Purchase> GetDataWithPagingAndSearch(string searchString, int pagNumber, int pageSize, out long total)
        {
            throw new NotImplementedException();
        }
    }
}
