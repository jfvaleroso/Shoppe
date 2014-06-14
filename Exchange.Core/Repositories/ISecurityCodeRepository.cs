using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Repositories
{
    public interface ISecurityCodeRepository : IRepository<SecurityCode, Guid>, ISearchRepository<SecurityCode>,
        IValidateRepository<SecurityCode>
    {
        SecurityCode GetDataByCode(string searchString);
    }
}