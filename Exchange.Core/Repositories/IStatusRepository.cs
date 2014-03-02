using Exchange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Repositories
{
    public interface IStatusRepository : IRepository<Status, int>, ISearchRepository<Status>, IValidateRepository<Status>
    {
    }
}
