using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Services.Implementation
{
    public class PurchaseService : IPurchaseService
    {
        #region Constructor

        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        #endregion Constructor

        #region CRUD

        public void Save(Purchase entity)
        {
            _purchaseRepository.Save(entity);
        }

        public Guid Create(Purchase entity)
        {
            return _purchaseRepository.Create(entity);
        }

        public void SaveChanges(Purchase entity)
        {
            _purchaseRepository.Create(entity);
        }

        public void SaveOrUpdate(Purchase entity)
        {
            _purchaseRepository.SaveOrUpdate(entity);
        }

        public bool Delete(Guid id)
        {
            try
            {
                _purchaseRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion CRUD

        #region Search and Filter

        public Purchase GetDataById(Guid id)
        {
            return _purchaseRepository.Get(id);
        }

        public Purchase GetByExpression(Purchase entity)
        {
            return _purchaseRepository.GetByExpression(x => x.Product.Equals(entity.Product));
        }

        public List<Purchase> GetAllData()
        {
            return _purchaseRepository.GetAll().ToList();
        }

        public List<Purchase> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return _purchaseRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<Purchase> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            return _purchaseRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        #endregion Search and Filter
    }
}