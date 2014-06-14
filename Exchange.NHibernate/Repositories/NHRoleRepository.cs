using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHRoleRepository : NHRepositoryBase<Roles, Guid>, IRoleRepository
    {
        #region Role Method

        public Roles GetRoleByRoleNameApplicationName(string roleName, string applicationName)
        {
            var role = Session.CreateCriteria(typeof(Roles))
                .Add(Restrictions.Eq("RoleName", roleName))
                .Add(Restrictions.Eq("ApplicationName", applicationName))
                .UniqueResult<Roles>();
            return role;
        }

        public IList<Roles> GetRolesByApplicationName(string applicationName)
        {
            IList<Roles> allroles = Session.CreateCriteria(typeof(Roles))
                .Add(Restrictions.Eq("ApplicationName", applicationName))
                .List<Roles>();
            return allroles;
        }

        #endregion Role Method

        public List<Roles> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return GetDataWithPagingAndSearch(RoleFilter.Search(searchString), RoleFilter.Alias(), RoleFilter.Orders(),
                pageIndex, pageSize, out total);
        }
    }
}