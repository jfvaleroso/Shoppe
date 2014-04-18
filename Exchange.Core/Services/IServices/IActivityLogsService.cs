using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;

namespace Exchange.Core.Services.IServices
{
    public interface IActivityLogsService : IService<ActivityLogs, Guid>
    {
        void CreateAuditLog(string userName, string ipAddress, string areaAccessed, DateTime timeAccessed, string action, string result);
    }
}
