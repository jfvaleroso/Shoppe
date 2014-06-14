using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using Exchange.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Services.Implementation
{
    public class ProductTypeService : IProductTypeService
    {
        #region Constructor

        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        #endregion Constructor

        #region CRUD

        public void Save(ProductType entity)
        {
            _productTypeRepository.Save(entity);
        }

        public Guid Create(ProductType entity)
        {
            return _productTypeRepository.Create(entity);
        }

        public void SaveChanges(ProductType entity)
        {
            _productTypeRepository.SaveChanges(entity);
        }

        public void SaveOrUpdate(ProductType productType)
        {
            _productTypeRepository.SaveOrUpdate(productType);
        }

        [UnitOfWork]
        public bool Delete(Guid id)
        {
            try
            {
                _productTypeRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion CRUD

        #region Search and Filter

        public ProductType GetDataById(Guid id)
        {
            return _productTypeRepository.Get(id);
        }

        public List<ProductType> GetDataListByStatus(bool active)
        {
            return _productTypeRepository.Get(x => x.Active.Equals(active)).ToList();
        }

        public ProductType GetByExpression(ProductType entity)
        {
            return _productTypeRepository.GetByExpression(x => x.Code.Equals(entity.Code));
        }

        public List<ProductType> GetAllData()
        {
            return _productTypeRepository.GetAll().ToList();
        }

        [UnitOfWork]
        public List<ProductType> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return _productTypeRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        [UnitOfWork]
        public List<ProductType> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            return _productTypeRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        #endregion Search and Filter

        #region Validator

        public bool CheckDataIfExists(ProductType entity)
        {
            var parameter = new Dictionary<string, object>();
            parameter.Add("Code", entity.Code);
            parameter.Add("Name", entity.Name);
            parameter.Add("Active", entity.Active);
            List<ProductType> process = _productTypeRepository.CheckIfDataExists(parameter);
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
            List<ProductType> process = _productTypeRepository.CheckIfDataExists(parameter);
            if (process.Count() > 0)
            {
                return true;
            }
            return false;
        }

        #endregion Validator
    }
}