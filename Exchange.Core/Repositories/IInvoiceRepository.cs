using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice, Guid>
    {
        long GetTotalInvoiceBySTore(Guid storeId);
    }
}