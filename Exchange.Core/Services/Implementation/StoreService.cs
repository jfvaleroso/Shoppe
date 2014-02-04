using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Services.IServices;
using Exchange.Core.Repositories;
using Exchange.Core.Entities;
using Exchange.Core.UnitOfWork;
using System.Web;



namespace Exchange.Core.Services.Implementation
{
    public class StoreService : IStoreService
    {

        #region Constructor
        private readonly IStoreRepository storeRepository;
        public StoreService(IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
        }
        #endregion
        #region CRUD
        public void Save(Store store)
        {
            this.storeRepository.Save(store);
        }
        public int Create(Store store)
        {
            return this.storeRepository.Create(store);
        }

        public void SaveChanges(Store store)
        {
            this.storeRepository.SaveChanges(store);
        }
        public void SaveOrUpdate(Store store)
        {
            this.storeRepository.SaveOrUpdate(store);
        }

        [UnitOfWork]
        public bool Delete(int storeId)
        {
            try
            {
                this.storeRepository.Delete(storeId);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        #endregion
        #region Seach and Filter
        public Store GetDataById(int id)
        {
            return this.storeRepository.Get(id);
        }
        public Store GetByExpression(Store entity)
        {
            return this.storeRepository.GetByExpression(x => x.Name.Equals(entity.Name));
        }
        public List<Store> GetDataListByStatus(bool active)
        {
            return this.storeRepository.Get(x => x.Active.Equals(active)).ToList();
        }
        public List<Store> GetAllData()
        {
            return this.storeRepository.GetAll().ToList();
        }
        [UnitOfWork]
        public List<Store> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.storeRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        [UnitOfWork]
        public List<Store> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.storeRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        #endregion
        #region Validtor
        public bool CheckDataIfExists(Store entity)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("Code", entity.Code);
            parameter.Add("Name", entity.Name);
            parameter.Add("Address", entity.Address);
            parameter.Add("TelephoneNo", entity.TelephoneNo);
            parameter.Add("PermitNo", entity.PermitNo);
            parameter.Add("TINNo", entity.TINNo);
            parameter.Add("Active", entity.Active);
            List<Store> process = this.storeRepository.CheckIfDataExists(parameter);
            if (process.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckDataIfExists(string param)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("Code", param);
            List<Store> process = this.storeRepository.CheckIfDataExists(parameter);
            if (process.Count() > 0)
            {
                return true;
            }
            return false;
        }
        #endregion


      
    }
}
