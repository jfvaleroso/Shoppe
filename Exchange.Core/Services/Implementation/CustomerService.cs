using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        #region Constructor

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #endregion Constructor

        #region CRUD

        public void Save(Customer entity)
        {
            _customerRepository.Save(entity);
        }

        public Guid Create(Customer entity)
        {
            return _customerRepository.Create(entity);
        }

        public void SaveChanges(Customer entity)
        {
            _customerRepository.SaveChanges(entity);
        }

        public void SaveOrUpdate(Customer entity)
        {
            _customerRepository.SaveOrUpdate(entity);
        }

        public bool Delete(Guid id)
        {
            try
            {
                _customerRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion CRUD

        #region Search and Filter

        public Customer GetDataById(Guid id)
        {
            return _customerRepository.Get(id);
        }

        public Customer GetByExpression(Customer entity)
        {
            return _customerRepository.GetByExpression(x => x.LastName.Equals(entity.LastName));
        }

        public List<Customer> GetAllData()
        {
            return _customerRepository.GetAll().ToList();
        }

        public List<Customer> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return _customerRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<Customer> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            return _customerRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        #endregion Search and Filter
    }
}