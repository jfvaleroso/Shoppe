using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHInvoiceRepository : NHRepositoryBase<Invoice, long>, IInvoiceRepository
    {
        public long GetTotalInvoiceBySTore(int storeId)
        {
            return this.GetTotalCount(InvoiceFilter.SearchByStore(storeId), InvoiceFilter.AliasByStore(), InvoiceFilter.Orders());
        }
    }
}
