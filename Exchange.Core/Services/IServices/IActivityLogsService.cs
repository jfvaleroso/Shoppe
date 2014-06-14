using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Services.IServices
{
    public interface IActivityLogsService : IService<ActivityLogs, Guid>
    {
        void CreateAuditLog(string userName, string ipAddress, string areaAccessed, DateTime timeAccessed, string action,
            string result);
    }
}