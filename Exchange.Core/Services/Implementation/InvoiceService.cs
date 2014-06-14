using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Services.Implementation
{
    public class InvoiceService : IInvoiceService
    {
        #region Constructor

        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        #endregion Constructor

        #region CRUD

        public void Save(Invoice entity)
        {
            _invoiceRepository.Save(entity);
        }

        public Guid Create(Invoice entity)
        {
            return _invoiceRepository.Create(entity);
        }

        public void SaveChanges(Invoice entity)
        {
            _invoiceRepository.Create(entity);
        }

        public void SaveOrUpdate(Invoice entity)
        {
            _invoiceRepository.SaveOrUpdate(entity);
        }

        public bool Delete(Guid id)
        {
            try
            {
                _invoiceRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion CRUD

        #region Search and Filter

        public Invoice GetDataById(Guid id)
        {
            return _invoiceRepository.Get(id);
        }

        public Invoice GetByExpression(Invoice entity)
        {
            return _invoiceRepository.GetByExpression(x => x.Customer.Equals(entity.Customer));
        }

        public List<Invoice> GetAllData()
        {
            return _invoiceRepository.GetAll().ToList();
        }

        public List<Invoice> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return _invoiceRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        #endregion Search and Filter

        public List<Invoice> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            throw new NotImplementedException();
        }

        public long GetTotalInvoiceBySTore(Guid storeId)
        {
            return _invoiceRepository.GetTotalInvoiceBySTore(storeId);
        }
    }
}