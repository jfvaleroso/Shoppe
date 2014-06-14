using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Services.IServices
{
    public interface ISecurityCodeService : IService<SecurityCode, Guid>
    {
        SecurityCode GetDataByCode(string searchString);
    }
}