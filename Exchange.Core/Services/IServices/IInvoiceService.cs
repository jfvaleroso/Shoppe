using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Services.IServices
{
    public interface IInvoiceService : IService<Invoice, Guid>
    {
        long GetTotalInvoiceBySTore(Guid storeId);
    }
}