using Exchange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Services.IServices
{
    public interface IStatusService : IService<Status, Guid>
    {
        Status GetStatusByCode(string code);
    }
}
