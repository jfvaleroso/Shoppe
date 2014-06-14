using Exchange.Core.Entities;
using System;
using System.Collections.Generic;

namespace Exchange.Core.Repositories
{
    public interface IProfileRepository : IRepository<Profiles, Guid>, ISearchRepository<Profiles>
    {
        #region Profile

        Profiles GetProfileByUserId(Guid userId, bool isAnonymous);

        Profiles GetProfileByUserId(Guid userId);

        IList<Profiles> GetProfilesByAppplicationNameLastActivityDate(string applicationName,
            DateTime userInactiveSinceDate, bool isAnonymous);

        IList<Profiles> GeProfilesByAppplicationNameLastActivityDateIsAnonymous(string applicationName,
            DateTime userInactiveSinceDate, bool isAnonymous);

        #endregion Profile
    }
}