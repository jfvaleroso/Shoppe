using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHProfileRepository : NHRepositoryBase<Profiles, Guid>, IProfileRepository
    {
        #region Profile Method

        public Profiles GetProfileByUserId(Guid userId, bool isAnonymous)
        {
            var profile = Session.CreateCriteria(typeof(Profiles))
                .Add(Restrictions.Eq("UserId", userId))
                .Add(Restrictions.Eq("IsAnonymous", isAnonymous))
                .UniqueResult<Profiles>();
            return profile;
        }

        public Profiles GetProfileByUserId(Guid userId)
        {
            var profile = Session.CreateCriteria(typeof(Profiles))
                .Add(Restrictions.Eq("UserId", userId))
                .UniqueResult<Profiles>();
            return profile;
        }

        public IList<Profiles> GetProfilesByAppplicationNameLastActivityDate(string applicationName,
            DateTime userInactiveSinceDate, bool isAnonymous)
        {
            IList<Profiles> profiles = Session.CreateCriteria(typeof(Profiles))
                .Add(Restrictions.Eq("ApplicationName", applicationName))
                .Add(Restrictions.Le("LastActivityDate", userInactiveSinceDate))
                .Add(Restrictions.Eq("IsAnonymous", isAnonymous))
                .List<Profiles>();
            return profiles;
        }

        public IList<Profiles> GeProfilesByAppplicationNameLastActivityDateIsAnonymous(string applicationName,
            DateTime userInactiveSinceDate, bool isAnonymous)
        {
            ICriteria cprofiles = Session.CreateCriteria(typeof(Profiles));
            cprofiles.Add(Restrictions.Eq("ApplicationName", applicationName));
            if (userInactiveSinceDate != null)
                cprofiles.Add(Restrictions.Le("LastActivityDate", userInactiveSinceDate));
            cprofiles.Add(Restrictions.Eq("IsAnonymous", isAnonymous));

            IList<Profiles> profiles = cprofiles.List<Profiles>();
            return profiles;
        }

        #endregion Profile Method

        public List<Profiles> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize,
            out long total)
        {
            return GetDataWithPagingAndSearch(ProfileFilter.Search(searchString), ProfileFilter.Alias(),
                ProfileFilter.Orders(), pageIndex, pageSize, out total);
        }
    }
}