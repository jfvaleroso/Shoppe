using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Repositories;
using Exchange.Core.UnitOfWork;
using Exchange.Core.Services.IServices;

using Exchange.Core.Entities;

namespace Exchange.Core.Services.Implementation
{
    public class ProductService : IProductService
    {

        #region Constructor
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        #endregion
        #region CRUD
        public void Save(Product product)
        {

            product.Code = product.Name.Substring(0, 5) + product.Id.ToString();
            this.productRepository.Save(product);
        }
        public int Create(Product product)
        {

            return this.productRepository.Create(product);
        }
        public void SaveChanges(Product product)
        {
            this.productRepository.SaveChanges(product);
        }
        public void SaveOrUpdate(Product product)
        {
            this.productRepository.SaveOrUpdate(product);
        }
        [UnitOfWork]
        public bool Delete(int productId)
        {
            try
            {
                this.productRepository.Delete(productId);
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        #endregion
        #region Seach and Filter
        public Product GetDataById(int id)
        {
            return this.productRepository.Get(id);
        }
        public Product GetByExpression(Product entity)
        {
            return this.productRepository.GetByExpression(x => x.Name.Equals(entity.Name));
        }
        [UnitOfWork]
        public List<Product> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.productRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }
        [UnitOfWork]
        public List<Product> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.productRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        #endregion
        #region Validator
        public bool CheckDataIfExists(Product entity)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("Code", entity.Code);
            parameter.Add("Cost", entity.Cost);
            parameter.Add("Name", entity.Name);
            parameter.Add("Description", entity.Name);
            parameter.Add("ProductType", entity.ProductType);
            parameter.Add("Active", entity.Active);
            List<Product> process = this.productRepository.CheckIfDataExists(parameter);
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
            List<Product> process = this.productRepository.CheckIfDataExists(parameter);
            if (process.Count() > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
