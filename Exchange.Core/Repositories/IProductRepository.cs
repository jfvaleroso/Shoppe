using Exchange.Core.Entities;
using System;
using System.Collections.Generic;

namespace Exchange.Core.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>, ISearchRepository<Product>,
        IValidateRepository<Product>
    {
        List<Product> Test();
    }
}