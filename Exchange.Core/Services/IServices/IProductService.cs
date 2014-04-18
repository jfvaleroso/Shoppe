using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;


namespace Exchange.Core.Services.IServices
{
    public interface IProductService : IService<Product, Guid>, IValidateService<Product>, IFilterService<Product>
    {
       
      
    }
}
