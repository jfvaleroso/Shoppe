using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using Exchange.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Services.Implementation
{
    public class StoreService : IStoreService
    {
        #region Constructor

        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        #endregion Constructor

        #region CRUD

        public void Save(Store store)
        {
            _storeRepository.Save(store);
        }

        public Guid Create(Store store)
        {
            return _storeRepository.Create(store);
        }

        public void SaveChanges(Store store)
        {
            _storeRepository.SaveChanges(store);
        }

        public void SaveOrUpdate(Store store)
        {
            _storeRepository.SaveOrUpdate(store);
        }

        [UnitOfWork]
        public bool Delete(Guid storeId)
        {
            try
            {
                _storeRepository.Delete(storeId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion CRUD

        #region Seach and Filter

        public Store GetDataById(Guid id)
        {
            return _storeRepository.Get(id);
        }

        public Store GetByExpression(Store entity)
        {
            return _storeRepository.GetByExpression(x => x.Name.Equals(entity.Name));
        }

        public List<Store> GetDataListByStatus(bool active)
        {
            return _storeRepository.Get(x => x.Active.Equals(active)).ToList();
        }

        public List<Store> GetAllData()
        {
            return _storeRepository.GetAll().ToList();
        }

        [UnitOfWork]
        public List<Store> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return _storeRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        [UnitOfWork]
        public List<Store> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            return _storeRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        #endregion Seach and Filter

        #region Validator

        public bool CheckDataIfExists(Store entity)
        {
            var parameter = new Dictionary<string, object>();
            parameter.Add("Code", entity.Code);
            parameter.Add("Name", entity.Name);
            parameter.Add("Address", entity.Address);
            parameter.Add("TelephoneNo", entity.TelephoneNo);
            parameter.Add("PermitNo", entity.PermitNo);
            parameter.Add("TINNo", entity.TINNo);
            parameter.Add("Active", entity.Active);
            List<Store> process = _storeRepository.CheckIfDataExists(parameter);
            if (process.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckDataIfExists(string param)
        {
            var parameter = new Dictionary<string, object>();
            parameter.Add("Code", param);
            List<Store> process = _storeRepository.CheckIfDataExists(parameter);
            if (process.Count() > 0)
            {
                return true;
            }
            return false;
        }

        #endregion Validator
    }
}