using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Repositories;
using Exchange.Core.Entities;

namespace Exchange.Core.Services.IServices
{
    public interface IUserService
    {    
        List<Users> GetUsersWithPaging(int pageIndex, int pageSize, out long total);
        List<Users> GetUsersWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total);
        Users GetUserById(int userId);
        Users GetUserByUsernameApplicationName(string username, string applicationName);
        void SaveOrUpdate(Users entity); 
        void SaveChanges(Users entity);


    }
}
