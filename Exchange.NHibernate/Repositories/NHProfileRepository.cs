using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using NHibernate;
using NHibernate.Criterion;
using Exchange.Helper;
using Exchange.Helper.Common;
using Exchange.NHibernateBase.Filters;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHProfileRepository : NHRepositoryBase<Profiles, Guid>, IProfileRepository
    {

        #region Profile Method
        public Profiles GetProfileByUserId(Guid userId, bool isAnonymous)
        {
            
           Profiles profile = Session.CreateCriteria(typeof(Profiles))
                                            .Add(NHibernate.Criterion.Restrictions.Eq("Users_Id", userId))
                                            .Add(NHibernate.Criterion.Restrictions.Eq("IsAnonymous", isAnonymous))
                                            .UniqueResult<Profiles>();
           return profile;
        }
        public Profiles GetProfileByUserId(Guid userId)
        {
            Profiles profile = Session.CreateCriteria(typeof(Profiles))
                                            .Add(NHibernate.Criterion.Restrictions.Eq("Users_Id", userId))
                                            .UniqueResult<Profiles>();
            return profile;
        }
        public IList<Profiles> GetProfilesByAppplicationNameLastActivityDate(string applicationName, DateTime userInactiveSinceDate, bool isAnonymous)
        {
            IList<Profiles> profiles = Session.CreateCriteria(typeof(Profiles))
                                                   .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName))
                                                   .Add(NHibernate.Criterion.Restrictions.Le("LastActivityDate", userInactiveSinceDate))
                                                   .Add(NHibernate.Criterion.Restrictions.Eq("IsAnonymous", isAnonymous))
                                                   .List<Profiles>();
            return profiles;
        }
        public IList<Profiles> GeProfilesByAppplicationNameLastActivityDateIsAnonymous(string applicationName, DateTime userInactiveSinceDate, bool isAnonymous)
        {
            ICriteria cprofiles = Session.CreateCriteria(typeof(Profiles));
            cprofiles.Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", applicationName));
            if (userInactiveSinceDate != null)
                cprofiles.Add(NHibernate.Criterion.Restrictions.Le("LastActivityDate", (DateTime)userInactiveSinceDate));
            cprofiles.Add(NHibernate.Criterion.Restrictions.Eq("IsAnonymous", isAnonymous));

            IList<Profiles> profiles = cprofiles.List<Profiles>();
            return profiles;
        }
        #endregion

        public List<Profiles> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return this.GetDataWithPagingAndSearch(ProfileFilter.Search(searchString), ProfileFilter.Alias(), ProfileFilter.Orders(), pageIndex, pageSize, out total);
        }
    }
}
