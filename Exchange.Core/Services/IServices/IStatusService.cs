using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Services.IServices
{
    public interface IStatusService : IService<Status, Guid>
    {
        Status GetStatusByCode(string code);
    }
}