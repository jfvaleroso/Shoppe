using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Repositories
{
    public interface IProductTypeRepository : IRepository<ProductType, Guid>, ISearchRepository<ProductType>,
        IValidateRepository<ProductType>
    {
    }
}