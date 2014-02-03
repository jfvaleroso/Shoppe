using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Services.IServices;
using Exchange.Core.Repositories;

namespace Exchange.Core.Services.Implementation
{
    public class UserService:IUserService
    {

        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
	    {
            this.userRepository = userRepository;
	    }





       
        public List<Entities.Users> GetUsersWithPaging(int pageIndex, int pageSize, out long total)
        {
            return this.userRepository.GetDataWithPaging(pageIndex, pageSize, out total);
        }

        public List<Entities.Users> GetUsersWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return this.userRepository.GetDataWithPagingAndSearch(searchString, pageIndex, pageSize, out total);
        }

       
        public Entities.Users GetUserById(int userId)
        {
            return this.userRepository.Get(userId);
        }


        public Entities.Users GetUserByUsernameApplicationName(string username, string applicationName)
        {
            return this.userRepository.GetUserByUsernameApplicationName(username, applicationName);
        }
    }
}
