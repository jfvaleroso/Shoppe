using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHSecurityCodeRepository : NHRepositoryBase<SecurityCode, Guid>, ISecurityCodeRepository
    {
        public List<SecurityCode> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return this.GetDataWithPagingAndSearch(SecurityCodeFilter.Search(searchString), CustomerFilter.Alias(), CustomerFilter.Orders(), pageIndex, pageSize, out total);
        }

        public SecurityCode GetDataByCode(string searchString)
        {
            return this.GetFilteredDataByParameter(SecurityCodeFilter.SearchByCode(searchString));
        }
    }
}
