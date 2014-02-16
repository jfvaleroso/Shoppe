using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHInvoiceRepository : NHRepositoryBase<Invoice, long>, IInvoiceRepository
    {
    }
}
