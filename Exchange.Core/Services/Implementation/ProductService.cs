using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using Exchange.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Services.Implementation
{
    public class ProductService : IProductService
    {
        #region Constructor

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion Constructor

        #region CRUD

        public void Save(Product product)
        {
            product.Code = product.Name.Substring(0, 5) + product.Id;
            _productRepository.Save(product);
        }

        public Guid Create(Product product)
        {
            return _productRepository.Create(product);
        }

        public void SaveChanges(Product product)
        {
            _productRepository.SaveChanges(product);
        }

        public void SaveOrUpdate(Product product)
        {
            _productRepository.SaveOrUpdate(product);
        }

        [UnitOfWork]
        public bool Delete(Guid productId)
        {
            try
            {
                _productRepository.Delete(productId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion CRUD

        #region Seach and Filter

        public List<Product> GetDataListByStatus(bool active)
        {
            return _productRepository.Get(x => x.Active.Equals(active)).ToList();
        }

        public Product GetDataById(Guid id)
        {
            return _productRepository.Get(id);
        }

        public Product GetByExpression(Product entity)
        {
            return _productRepository.GetByExpression(x => x.Name.Equals(entity.Name));
        }

        public List<Product> GetAllData()
        {
            return _productRepository.Test();
        }

        [UnitOfWork]
        public List<Product> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return _productRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        [UnitOfWork]
        public List<Product> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            return _productRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        #endregion Seach and Filter

        #region Validator

        public bool CheckDataIfExists(Product entity)
        {
            var parameter = new Dictionary<string, object>();
            parameter.Add("Code", entity.Code);
            parameter.Add("Cost", entity.Cost);
            parameter.Add("Name", entity.Name);
            parameter.Add("Description", entity.Name);
            parameter.Add("ProductType", entity.ProductType);
            parameter.Add("Active", entity.Active);
            List<Product> process = _productRepository.CheckIfDataExists(parameter);
            return process.Any();
        }

        public bool CheckDataIfExists(string param)
        {
            var parameter = new Dictionary<string, object>();
            parameter.Add("Code", param);
            List<Product> process = _productRepository.CheckIfDataExists(parameter);
            return process.Any();
        }

        #endregion Validator
    }
}