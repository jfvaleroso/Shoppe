using Exchange.Core.Entities;
using System;
using System.Collections.Generic;

namespace Exchange.Core.Services.IServices
{
    public interface IUserService : IService<Users, Guid>
    {
        IList<Users> GetUsersByApplicationName(string applicationName);

        List<Users> GetUsersWithPaging(int pageIndex, int pageSize, out long total);

        List<Users> GetUsersWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total);

        Users GetUserById(Guid userId);

        Users GetUserByUsernameApplicationName(string username, string applicationName);

        Users GetUserByIdApplicationName(Guid userId, string applicationName);
    }
}