using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;

namespace Exchange.Core.Services.IServices
{
    public interface IProductTypeService : IService<ProductType, int>, IValidateService<ProductType>, IFilterService<ProductType>
    {
        
    }
}
