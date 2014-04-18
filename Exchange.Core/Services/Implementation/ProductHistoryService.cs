﻿using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Services.Implementation
{
    public class ProductHistoryService : IProductHistoryService
    {

        #region Constructor
        private readonly IProductHistoryRepository productHistoryRepository;
        public ProductHistoryService(IProductHistoryRepository productHistoryRepository)
        {
            this.productHistoryRepository = productHistoryRepository;
        }
        #endregion
        #region Search and Filter
        public List<ProductHistory> GetAllData()
        {
            return this.productHistoryRepository.GetAll().ToList();
        }
        public List<ProductHistory> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.productHistoryRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }
        #endregion
        #region CRUD
        public void Save(ProductHistory entity)
        {
            this.productHistoryRepository.SaveOrUpdate(entity);
        }
        #endregion
        #region No Implementaion
        public ProductHistory GetDataById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductHistory GetByExpression(ProductHistory entity)
        {
            throw new NotImplementedException();
        }
        public List<ProductHistory> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            throw new NotImplementedException();
        }
        public Guid Create(ProductHistory entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges(ProductHistory entity)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(ProductHistory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion


      
    }
}
