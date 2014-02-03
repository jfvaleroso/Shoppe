using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Services.IServices;
using Exchange.Core.Repositories;
using Exchange.Core.Entities;

namespace Exchange.Core.Services.Implementation
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }


        public List<Roles> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.roleRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<Roles> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.roleRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        public void Save(Roles entity)
        {
            this.roleRepository.Save(entity);
        }
        public int Create(Roles entity)
        {
            return (int)this.roleRepository.Create(entity);
        }

        public void SaveChanges(Roles entity)
        {
            this.roleRepository.SaveChanges(entity);
        }
        public void SaveOrUpdate(Roles entity)
        {
            this.roleRepository.SaveOrUpdate(entity);
        }

        public bool Delete(int id)
        {
            try
            {
                this.roleRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public Roles GetDataById(int id)
        {
            return this.roleRepository.Get(id);
        }
        public Roles GetByExpression(Roles entity)
        {
            return this.roleRepository.GetByExpression(x => x.RoleName.Equals(entity.RoleName));
        }
        #region Validator
        public bool CheckDataIfExists(Roles entity)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("RoleName", entity.RoleName);
            parameter.Add("Description", entity.Description);
            List<Roles> role = this.roleRepository.CheckIfDataExists(parameter);
            if (role.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckDataIfExists(string param)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("RoleName", param);
            List<Roles> role = this.roleRepository.CheckIfDataExists(parameter);
            if (role.Count() > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
