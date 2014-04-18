using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;

namespace Exchange.Core.Services.Implementation
{
    public class SecurityCodeService : ISecurityCodeService
    {
        #region Constructor
        private readonly ISecurityCodeRepository securityCodeRepository;
        public SecurityCodeService(ISecurityCodeRepository securityCodeRepository)
        {
            this.securityCodeRepository = securityCodeRepository;
        }
        #endregion
        #region CRUD
        public void Save(SecurityCode entity)
        {
            this.securityCodeRepository.Save(entity);
        }
        public Guid Create(SecurityCode entity)
        {

            return this.securityCodeRepository.Create(entity);
        }
        public void SaveChanges(SecurityCode entity)
        {
            this.securityCodeRepository.SaveChanges(entity);
        }
        public void SaveOrUpdate(SecurityCode entity)
        {
            this.securityCodeRepository.SaveOrUpdate(entity);
        }

        public bool Delete(Guid productId)
        {
            try
            {
                this.securityCodeRepository.Delete(productId);
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        #endregion
        #region Seach and Filter
        public List<SecurityCode> GetDataListByStatus(bool isUsed)
        {
            return this.securityCodeRepository.Get(x => x.IsUsed.Equals(isUsed)).ToList();
        }
        public SecurityCode GetDataById(Guid id)
        {
            return this.securityCodeRepository.Get(id);
        }
        public SecurityCode GetByExpression(SecurityCode entity)
        {
            return this.securityCodeRepository.GetByExpression(x => x.PassCode.Equals(entity.PassCode));
        }
        public List<SecurityCode> GetAllData()
        {
            return this.securityCodeRepository.GetAll().ToList();
        }
     
        public List<SecurityCode> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.securityCodeRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        } 
        public List<SecurityCode> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.securityCodeRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        #endregion


        public SecurityCode GetDataByCode(string searchString)
        {
            return this.securityCodeRepository.GetDataByCode(searchString);
        }
    }
}
