using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Services.IServices;
using Exchange.Core.Repositories;
using Exchange.Core.Entities;
using Exchange.Core.UnitOfWork;


namespace Exchange.Core.Services.Implementation
{
    public class CustomerService: ICustomerService
    {

        #region Constructor
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        #endregion
        #region CRUD
        public void Save(Customer entity)
        {
            this.customerRepository.Save(entity);
        }

        public Guid Create(Customer entity)
        {
            return this.customerRepository.Create(entity);
        }

        public void SaveChanges(Customer entity)
        {
            this.customerRepository.SaveChanges(entity);
        }

        public void SaveOrUpdate(Customer entity)
        {
            this.customerRepository.SaveOrUpdate(entity);
        }

        public bool Delete(Guid id)
        {
            try
            {
                this.customerRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion
        #region Search and Filter
        public Customer GetDataById(Guid id)
        {
            return this.customerRepository.Get(id);
        }

        public Customer GetByExpression(Customer entity)
        {
            return this.customerRepository.GetByExpression(x => x.LastName.Equals(entity.LastName));
        }
        public List<Customer> GetAllData()
        {
            return this.customerRepository.GetAll().ToList();
        }
        public List<Customer> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.customerRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<Customer> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.customerRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }
        #endregion

       

       
    }
}
