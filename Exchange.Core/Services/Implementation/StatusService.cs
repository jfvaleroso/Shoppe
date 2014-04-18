using Exchange.Core.Services.IServices;
using Exchange.Core.Repositories;
using Exchange.Core.UnitOfWork;
using Exchange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Services.Implementation
{
    public class StatusService: IStatusService
    {
          #region Constructor
        private readonly IStatusRepository statusRepository;
        public StatusService(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }
       #endregion
        #region CRUD
        public void Save(Status entity)
        {
            this.statusRepository.Save(entity);
        }
        public Guid Create(Status entity)
        {
           return this.statusRepository.Create(entity);
        }
        public void SaveChanges(Status entity)
        {
            this.statusRepository.SaveChanges(entity);
        }
        public void SaveOrUpdate(Status productType)
        {
            this.statusRepository.SaveOrUpdate(productType);
        }
        [UnitOfWork]
        public bool Delete(Guid id)
        {
            try
            {
                this.statusRepository.Delete(id);
                return true;
            }
            catch
            {
                
                return false;
            }
            
        }
        #endregion
        #region Search and Filter
        public Status GetDataById(Guid id)
       {
           return this.statusRepository.Get(id);
       }
        public List<Status> GetDataListByStatus(bool active)
        {
            return this.statusRepository.Get(x => x.Active.Equals(active)).ToList();
        }
        public Status GetByExpression(Status entity)
        {
            return this.statusRepository.GetByExpression(x => x.Name.Equals(entity.Name));
        }
        public List<Status> GetAllData()
        {
            return this.statusRepository.GetAll().ToList();
        }
        [UnitOfWork]
        public List<Status> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.statusRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }
        [UnitOfWork]
        public List<Status> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.statusRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }
        #endregion
        #region Validator
        public bool CheckDataIfExists(Status entity)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("Name", entity.Name);
            parameter.Add("Description", entity.Description);
            parameter.Add("Active", entity.Active);
            List<Status> process = this.statusRepository.CheckIfDataExists(parameter);
            if (process.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckDataIfExists(string param)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("Name", param);
            List<Status> process = this.statusRepository.CheckIfDataExists(parameter);
            if (process.Count() > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        public Status GetStatusByCode(string code)
        {
            return this.statusRepository.GetByExpression(x => x.Code.Equals(code));
        }
    }
}
