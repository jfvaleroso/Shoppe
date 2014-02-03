using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;

namespace Exchange.Core.Repositories
{
    public interface IProfileRepository : IRepository<Profiles, int>, ISearchRepository<Profiles>
    {
        #region Profile
        Profiles GetProfileByUserId(int userId,bool isAnonymous);
        Profiles GetProfileByUserId(int userId);
        IList<Profiles> GetProfilesByAppplicationNameLastActivityDate(string applicationName, DateTime userInactiveSinceDate, bool isAnonymous);
        IList<Profiles> GeProfilesByAppplicationNameLastActivityDateIsAnonymous(string applicationName, DateTime userInactiveSinceDate, bool isAnonymous);
        #endregion
    }
}
