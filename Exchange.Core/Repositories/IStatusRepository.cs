using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Repositories
{
    public interface IStatusRepository : IRepository<Status, Guid>, ISearchRepository<Status>,
        IValidateRepository<Status>
    {
    }
}