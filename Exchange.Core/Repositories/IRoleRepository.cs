using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;

namespace Exchange.Core.Repositories
{
    public interface IRoleRepository : IRepository<Roles, int>, ISearchRepository<Roles>, IValidateRepository<Roles>
    {
        #region Roles
        Roles GetRoleByRoleNameApplicationName(string roleName, string applicationName);
        IList<Roles> GetRolesByApplicationName(string applicationName);
        #endregion

        

    }
}
