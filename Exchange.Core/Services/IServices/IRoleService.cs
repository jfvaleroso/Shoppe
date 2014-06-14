using Exchange.Core.Entities;
using System;
using System.Collections.Generic;

namespace Exchange.Core.Services.IServices
{
    public interface IRoleService : IService<Roles, Guid>, IValidateService<Roles>
    {
        Roles GetDataByName(string roleName);

        Roles GetDataByName(string roleName, string applicationName);

        IList<Roles> GetDataByApplicationName(string applicationName);
    }
}