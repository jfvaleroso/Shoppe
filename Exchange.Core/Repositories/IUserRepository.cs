using Exchange.Core.Entities;
using System;
using System.Collections.Generic;

namespace Exchange.Core.Repositories
{
    public interface IUserRepository : IRepository<Users, Guid>, ISearchRepository<Users>
    {
        #region Membership

        Users GetUserByIdUserKey(object providerUserKey);

        Users GetUserByUsernameApplicationName(string username, string applicationName);

        Users GetUserByEmailApplicationName(string email, string applicationName);

        Users GetUserByIdApplicationName(Guid userId, string applicationName);

        IList<Users> GetUsersByAppplicationName(string applicationName);

        IList<Users> GetUsersLikeUsername(string usernameToMatch, string applicationName);

        IList<Users> GetUsersLikeEmail(string emailToMatch, string applicationName);

        int GetTotalRecord(string applicationName);

        int GetTotalOnlineUsers(string applicationName, DateTime compareTime);

        #endregion Membership
    }
}