using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Services.Implementation
{
    public class SecurityCodeService : ISecurityCodeService
    {
        #region Constructor

        private readonly ISecurityCodeRepository _securityCodeRepository;

        public SecurityCodeService(ISecurityCodeRepository securityCodeRepository)
        {
            _securityCodeRepository = securityCodeRepository;
        }

        #endregion Constructor

        #region CRUD

        public void Save(SecurityCode entity)
        {
            _securityCodeRepository.Save(entity);
        }

        public Guid Create(SecurityCode entity)
        {
            return _securityCodeRepository.Create(entity);
        }

        public void SaveChanges(SecurityCode entity)
        {
            _securityCodeRepository.SaveChanges(entity);
        }

        public void SaveOrUpdate(SecurityCode entity)
        {
            _securityCodeRepository.SaveOrUpdate(entity);
        }

        public bool Delete(Guid productId)
        {
            try
            {
                _securityCodeRepository.Delete(productId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion CRUD

        #region Seach and Filter

        public SecurityCode GetDataById(Guid id)
        {
            return _securityCodeRepository.Get(id);
        }

        public SecurityCode GetByExpression(SecurityCode entity)
        {
            return _securityCodeRepository.GetByExpression(x => x.PassCode.Equals(entity.PassCode));
        }

        public List<SecurityCode> GetAllData()
        {
            return _securityCodeRepository.GetAll().ToList();
        }

        public List<SecurityCode> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return _securityCodeRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<SecurityCode> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            return _securityCodeRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        public List<SecurityCode> GetDataListByStatus(bool isUsed)
        {
            return _securityCodeRepository.Get(x => x.IsUsed.Equals(isUsed)).ToList();
        }

        #endregion Seach and Filter

        public SecurityCode GetDataByCode(string searchString)
        {
            return _securityCodeRepository.GetDataByCode(searchString);
        }
    }
}