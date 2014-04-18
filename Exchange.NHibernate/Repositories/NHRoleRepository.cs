using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using NHibernate.Criterion;
using Exchange.Helper;
using Exchange.Helper.Common;
using Exchange.NHibernateBase.Filters;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHRoleRepository : NHRepositoryBase<Roles, Guid>, IRoleRepository
    {

        #region Role Method
        public Roles GetRoleByRoleNameApplicationName(string roleName, string applicationName )
        {
            Roles role = Session.CreateCriteria(typeof(Roles))
                                              .Add(NHibernate.Criterion.Restrictions.Eq("RoleName", roleName))
                                              .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                                              .UniqueResult<Roles>();
            return role;
        }
        public IList<Roles> GetRolesByApplicationName(string applicationName)
        {
            IList<Roles> allroles = Session.CreateCriteria(typeof(Roles))
                                           .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                                           .List<Roles>();
            return allroles;
        }
        #endregion

        public List<Roles> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return this.GetDataWithPagingAndSearch(RoleFilter.Search(searchString), RoleFilter.Alias(), RoleFilter.Orders(), pageIndex, pageSize, out total);
        }
    }
}
