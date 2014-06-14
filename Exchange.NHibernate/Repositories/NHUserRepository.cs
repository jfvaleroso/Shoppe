using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHUserRepository : NHRepositoryBase<Users, Guid>, IUserRepository
    {
        #region Membership User Method

        public Users GetUserByIdUserKey(object providerUserKey)
        {
            var user = new Users();
            user = Session.CreateCriteria(typeof(Users))
                .Add(Restrictions.Eq("Id", (int)providerUserKey))
                .UniqueResult<Users>();
            return user;
        }

        public Users GetUserByUsernameApplicationName(string username, string applicationName)
        {
            var user = new Users();
            user = Session.CreateCriteria(typeof(Users))
                .Add(Restrictions.Eq("Username", username))
                .Add(Restrictions.Eq("ApplicationName", applicationName))
                .UniqueResult<Users>();
            return user;
        }

        public Users GetUserByEmailApplicationName(string email, string applicationName)
        {
            Users usr = null;
            try
            {
                usr = Session.CreateCriteria(typeof(Users))
                    .Add(Restrictions.Eq("Username", email))
                    .Add(Restrictions.Eq("ApplicationName", applicationName))
                    .UniqueResult<Users>();
            }
            catch (Exception e)
            {
                throw e;
            }
            return usr;
        }

        public Users GetUserByIdApplicationName(Guid Id, string applicationName)
        {
            Users usr = null;
            try
            {
                usr = Session.CreateCriteria(typeof(Users))
                    .Add(Restrictions.Eq("Id", Id))
                    .Add(Restrictions.Eq("ApplicationName", applicationName))
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
                    .Add(Restrictions.Eq("ApplicationName", applicationName))
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
                    .Add(Restrictions.Like("Username", usernameToMatch))
                    .Add(Restrictions.Eq("ApplicationName", applicationName))
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
                    .Add(Restrictions.Like("Email", emailToMatch))
                    .Add(Restrictions.Eq("ApplicationName", applicationName))
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
            var totalRecords = (Int32)Session.CreateCriteria(typeof(Users))
                .Add(Restrictions.Eq("ApplicationName", applicationName))
                .SetProjection(Projections.Count("Id")).UniqueResult();
            return totalRecords;
        }

        public int GetTotalOnlineUsers(string applicationName, DateTime compareTime)
        {
            var numOnline = (Int32)Session.CreateCriteria(typeof(Users))
                .Add(Restrictions.Eq("ApplicationName", applicationName))
                .Add(Restrictions.Gt("LastActivityDate", compareTime))
                .SetProjection(Projections.Count("Id")).UniqueResult();
            return numOnline;
        }

        #endregion Membership User Method

        public List<Users> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return GetDataWithPagingAndSearch(UserFilter.Search(searchString), UserFilter.Alias(), UserFilter.Orders(),
                pageIndex, pageSize, out total);
        }
    }
}