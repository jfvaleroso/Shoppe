using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Services.IServices;
using Exchange.Core.Repositories;
using Exchange.Core.UnitOfWork;
using Exchange.Core.Entities;

namespace Exchange.Core.Services.Implementation
{
    public class ProductTypeService : IProductTypeService
    {

        #region Constructor
        private readonly IProductTypeRepository productTypeRepository;
        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            this.productTypeRepository = productTypeRepository;
        }
       #endregion
        #region CRUD
        public void Save(ProductType entity)
        {
            this.productTypeRepository.Save(entity);
        }
        public int Create(ProductType entity)
        {
           return this.productTypeRepository.Create(entity);
        }
        public void SaveChanges(ProductType entity)
        {
            this.productTypeRepository.SaveChanges(entity);
        }
        public void SaveOrUpdate(ProductType productType)
        {
            this.productTypeRepository.SaveOrUpdate(productType);
        }
        [UnitOfWork]
        public bool Delete(int id)
        {
            try
            {
                this.productTypeRepository.Delete(id);
                return true;
            }
            catch
            {
                
                return false;
            }
            
        }
        #endregion
        #region Search and Filter
        public ProductType GetDataById(int id)
       {
           return this.productTypeRepository.Get(id);
       }
        public List<ProductType> GetDataListByStatus(bool active)
        {
            return this.productTypeRepository.Get(x => x.Active.Equals(active)).ToList();
        }
        public ProductType GetByExpression(ProductType entity)
        {
            return this.productTypeRepository.GetByExpression(x => x.Code.Equals(entity.Code));
        }
        public List<ProductType> GetAllData()
        {
            return this.productTypeRepository.GetAll().ToList();
        }
        [UnitOfWork]
        public List<ProductType> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.productTypeRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }
        [UnitOfWork]
        public List<ProductType> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.productTypeRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }
        #endregion
        #region Validator
        public bool CheckDataIfExists(ProductType entity)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("Code", entity.Code);
            parameter.Add("Name", entity.Name);
            parameter.Add("Active", entity.Active);
            List<ProductType> process = this.productTypeRepository.CheckIfDataExists(parameter);
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
            List<ProductType> process = this.productTypeRepository.CheckIfDataExists(parameter);
            if (process.Count() > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
