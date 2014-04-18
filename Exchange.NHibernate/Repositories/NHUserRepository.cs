using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Repositories;
using Exchange.Core.Entities;
using NHibernate.Criterion;
using Exchange.Helper;
using Exchange.Helper.Common;
using Exchange.NHibernateBase.Filters;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHUserRepository : NHRepositoryBase<Users, Guid>, IUserRepository
    {
        #region Membership User Method
        public Users GetUserByIdUserKey(object providerUserKey)
        {
            Users user = new Users();
            user = Session.CreateCriteria(typeof(Users))
                                     .Add(NHibernate.Criterion.Restrictions.Eq("Id", (int)providerUserKey))
                                     .UniqueResult<Users>();
            return user;
        }
        public Users GetUserByUsernameApplicationName(string username, string applicationName)
        {
            Users user = new Users();
            user = Session.CreateCriteria(typeof(Users))
                                      .Add(NHibernate.Criterion.Restrictions.Eq("Username", username))
                                      .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                                      .UniqueResult<Users>();
            return user;
        }
        public Users GetUserByEmailApplicationName(string email, string applicationName)
        {
            Users usr = null;
            try
            {
                usr = Session.CreateCriteria(typeof(Users))
                          .Add(NHibernate.Criterion.Restrictions.Eq("Username", email))
                          .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                          .UniqueResult<Users>();
            }
            catch (Exception e)
            {
                throw e;
            }
            return usr;
        }
        public Users GetUserByIdApplicationName(int Id, string applicationName)
        {
            Users usr = null;
            try
            {
                usr = Session.CreateCriteria(typeof(Users))
                          .Add(NHibernate.Criterion.Restrictions.Eq("Id", Id))
                          .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                          .UniqueResult<Users>();
            }
            catch (Exception e)
            {
                throw e;
            }
            return usr;
        }
        public IList<Users> GetUsersByAppplicationName(string applicationName)
        {
            IList<Users> usrs = null;
            try
            {
                usrs = Session.CreateCriteria(typeof(Users))
                                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                                .List<Users>();
            }
            catch (Exception e)
            {
                throw e;
            }
            return usrs;

        }
        public IList<Users> GetUsersLikeUsername(string usernameToMatch, string applicationName)
        {
            IList<Users> usrs = null;
            try
            {
                usrs = Session.CreateCriteria(typeof(Users))
                                .Add(NHibernate.Criterion.Restrictions.Like("Username", usernameToMatch))
                                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                                .List<Users>();
            }
            catch (Exception e)
            {
                throw e;
            }
            return usrs;
        }
        public IList<Users> GetUsersLikeEmail(string emailToMatch, string applicationName)
        {
            IList<Users> usrs = null;
            try
            {
                usrs = Session.CreateCriteria(typeof(Users))
                                .Add(NHibernate.Criterion.Restrictions.Like("Email", emailToMatch))
                                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                                .List<Users>();
            }
            catch (Exception e)
            {
                throw e;
            }
            return usrs;

        }
        public int GetTotalRecord(string applicationName)
        {
            int totalRecords = (Int32)Session.CreateCriteria(typeof(Users))
                                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                                .SetProjection(NHibernate.Criterion.Projections.Count("Id")).UniqueResult();
            return totalRecords;
        }
        public int GetTotalOnlineUsers(string applicationName, DateTime compareTime)
        {
            int numOnline = (Int32)Session.CreateCriteria(typeof(Users))
                                     .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                                     .Add(NHibernate.Criterion.Restrictions.Gt("LastActivityDate", compareTime))
                                     .SetProjection(NHibernate.Criterion.Projections.Count("Id")).UniqueResult();
            return numOnline;
        }
        #endregion





        public List<Users> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return this.GetDataWithPagingAndSearch(UserFilter.Search(searchString), UserFilter.Alias(), UserFilter.Orders(), pageIndex, pageSize, out total);
        }
     

    }
}
