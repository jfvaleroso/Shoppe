using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;

namespace Exchange.Core.Repositories
{
    public interface IUserRepository : IRepository<Users, int>, ISearchRepository<Users>
    {
        #region Membership
        Users GetUserByIdUserKey(object providerUserKey);
        Users GetUserByUsernameApplicationName(string username, string applicationName);
        Users GetUserByEmailApplicationName(string email, string applicationName);
        Users GetUserByIdApplicationName(int Id, string applicationName);
        IList<Users> GetUsersByAppplicationName(string applicationName);
        IList<Users> GetUsersLikeUsername(string usernameToMatch, string applicationName);
        IList<Users> GetUsersLikeEmail(string emailToMatch, string applicationName);
        int GetTotalRecord(string applicationName);
        int GetTotalOnlineUsers(string applicationName, DateTime compareTime);
        #endregion

      
    }
}
