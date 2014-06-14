using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Services.Implementation
{
    public class RoleService : IRoleService
    {
        #region Constructor

        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        #endregion Constructor

        #region CRUD

        public void Save(Roles entity)
        {
            _roleRepository.Save(entity);
        }

        public Guid Create(Roles entity)
        {
            return _roleRepository.Create(entity);
        }

        public void SaveChanges(Roles entity)
        {
            _roleRepository.SaveChanges(entity);
        }

        public void SaveOrUpdate(Roles entity)
        {
            _roleRepository.SaveOrUpdate(entity);
        }

        public bool Delete(Guid id)
        {
            try
            {
                _roleRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion CRUD

        #region Search and Filters

        public List<Roles> GetAllData()
        {
            return _roleRepository.GetAll().ToList();
        }

        public List<Roles> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return _roleRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<Roles> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            return _roleRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        public Roles GetDataById(Guid id)
        {
            return _roleRepository.Get(id);
        }

        public Roles GetDataByName(string roleName)
        {
            return _roleRepository.GetByExpression(x => x.RoleName.Equals(roleName));
        }

        public Roles GetDataByName(string roleName, string applicationName)
        {
            return
                _roleRepository.GetByExpression(
                    x => x.RoleName.Equals(roleName) && x.ApplicationName.Equals(applicationName));
        }

        public IList<Roles> GetDataByApplicationName(string applicationName)
        {
            return _roleRepository.GetRolesByApplicationName(applicationName);
        }

        public Roles GetByExpression(Roles entity)
        {
            return _roleRepository.GetByExpression(x => x.RoleName.Equals(entity.RoleName));
        }

        #endregion Search and Filters

        #region Validator

        public bool CheckDataIfExists(Roles entity)
        {
            var parameter = new Dictionary<string, object>();
            parameter.Add("RoleName", entity.RoleName);
            parameter.Add("Description", entity.Description);
            List<Roles> role = _roleRepository.CheckIfDataExists(parameter);
            if (role.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckDataIfExists(string param)
        {
            var parameter = new Dictionary<string, object>();
            parameter.Add("RoleName", param);
            List<Roles> role = _roleRepository.CheckIfDataExists(parameter);
            if (role.Count() > 0)
            {
                return true;
            }
            return false;
        }

        #endregion Validator
    }
}