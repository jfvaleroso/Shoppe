using Exchange.Core.Entities;
using System;
using System.Collections.Generic;

namespace Exchange.Core.Repositories
{
    public interface IRoleRepository : IRepository<Roles, Guid>, ISearchRepository<Roles>, IValidateRepository<Roles>
    {
        #region Roles

        Roles GetRoleByRoleNameApplicationName(string roleName, string applicationName);

        IList<Roles> GetRolesByApplicationName(string applicationName);

        #endregion Roles
    }
}