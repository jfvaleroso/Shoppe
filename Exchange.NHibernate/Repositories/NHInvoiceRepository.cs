using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHInvoiceRepository : NHRepositoryBase<Invoice, Guid>, IInvoiceRepository
    {
        public long GetTotalInvoiceBySTore(Guid storeId)
        {
            return GetTotalCount(InvoiceFilter.SearchByStore(storeId), InvoiceFilter.AliasByStore(),
                InvoiceFilter.Orders());
        }
    }
}