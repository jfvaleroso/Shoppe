using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Services.Implementation
{
    public class InvoiceService:IInvoiceService
    {
           #region Constructor
        private readonly IInvoiceRepository invoiceRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }
        #endregion
        #region CRUD
        public void Save(Invoice entity)
        {
            this.invoiceRepository.Save(entity);
        }

        public long Create(Invoice entity)
        {
            return this.invoiceRepository.Create(entity);
        }

        public void SaveChanges(Invoice entity)
        {
            this.invoiceRepository.Create(entity);
        }

        public void SaveOrUpdate(Invoice entity)
        {
            this.invoiceRepository.SaveOrUpdate(entity);
        }

        public bool Delete(long id)
        {
            try
            {
                this.invoiceRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        #region Search and Filter
        public Invoice GetDataById(long id)
        {
            return this.invoiceRepository.Get(id);
        }

        public Invoice GetByExpression(Invoice entity)
        {
            return this.invoiceRepository.GetByExpression(x => x.Customer.Equals(entity.Customer));
        }
        public List<Invoice> GetAllData()
        {
            return this.invoiceRepository.GetAll().ToList();
        }
        public List<Invoice> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.invoiceRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

      
        #endregion


        public List<Invoice> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            throw new NotImplementedException();
        }
    }
}
