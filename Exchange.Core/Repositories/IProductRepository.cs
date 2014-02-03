using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;

namespace Exchange.Core.Repositories
{
    public interface IProductRepository : IRepository<Product, int>, ISearchRepository<Product>, IValidateRepository<Product>
    {
       
    }
}
