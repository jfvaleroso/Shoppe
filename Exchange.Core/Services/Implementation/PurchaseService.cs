using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;

namespace Exchange.Core.Services.Implementation
{
    public class PurchaseService: IPurchaseService
    {
        private readonly IPurchaseRepository purchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }



        public Purchase GetDataById(long id)
        {
           return this.purchaseRepository.Get(id);
        }

        public Purchase GetByExpression(Purchase entity)
        {
            return this.purchaseRepository.GetByExpression(x => x.Cashier.Equals(entity.Cashier));
        }

        public List<Purchase> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.purchaseRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<Purchase> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.purchaseRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        public void Save(Purchase entity)
        {
            this.purchaseRepository.Save(entity);
        }

        public long Create(Purchase entity)
        {
            return this.purchaseRepository.Create(entity);
        }

        public void SaveChanges(Purchase entity)
        {
            this.purchaseRepository.Create(entity);
        }

        public void SaveOrUpdate(Purchase entity)
        {
            this.purchaseRepository.SaveOrUpdate(entity);
        }

        public bool Delete(long id)
        {
            try
            {
                this.purchaseRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
