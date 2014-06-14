using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;

namespace Exchange.Core.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Save(Users entity)
        {
            _userRepository.Save(entity);
        }

        public List<Users> GetUsersWithPaging(int pageIndex, int pageSize, out long total)
        {
            return _userRepository.GetDataWithPaging(pageIndex, pageSize, out total);
        }

        public List<Users> GetUsersWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return _userRepository.GetDataWithPagingAndSearch(searchString, pageIndex, pageSize, out total);
        }

        public IList<Users> GetUsersByApplicationName(string applicationName)
        {
            return _userRepository.GetUsersByAppplicationName(applicationName);
        }

        public Users GetUserById(Guid userId)
        {
            return _userRepository.Get(userId);
        }

        public Users GetUserByUsernameApplicationName(string username, string applicationName)
        {
            return _userRepository.GetUserByUsernameApplicationName(username, applicationName);
        }

        public Users GetUserByIdApplicationName(Guid userId, string applicationName)
        {
            return _userRepository.GetUserByIdApplicationName(userId, applicationName);
        }

        public void SaveOrUpdate(Users entity)
        {
            _userRepository.SaveOrUpdate(entity);
        }

        public void SaveChanges(Users entity)
        {
            _userRepository.SaveOrUpdate(entity);
        }

        public Users GetDataById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Users GetByExpression(Users entity)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAllData()
        {
            throw new NotImplementedException();
        }

        public Guid Create(Users entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            try
            {
                _userRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}