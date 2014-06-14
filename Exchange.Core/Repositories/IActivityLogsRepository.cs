using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Repositories
{
    public interface IActivityLogsRepository : IRepository<ActivityLogs, Guid>, ISearchRepository<ActivityLogs>
    {
    }
}