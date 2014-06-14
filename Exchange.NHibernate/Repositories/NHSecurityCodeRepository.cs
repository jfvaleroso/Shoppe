using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHSecurityCodeRepository : NHRepositoryBase<SecurityCode, Guid>, ISecurityCodeRepository
    {
        public List<SecurityCode> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize,
            out long total)
        {
            return GetDataWithPagingAndSearch(SecurityCodeFilter.Search(searchString), CustomerFilter.Alias(),
                CustomerFilter.Orders(), pageIndex, pageSize, out total);
        }

        public SecurityCode GetDataByCode(string searchString)
        {
            return GetFilteredDataByParameter(SecurityCodeFilter.SearchByCode(searchString));
        }
    }
}