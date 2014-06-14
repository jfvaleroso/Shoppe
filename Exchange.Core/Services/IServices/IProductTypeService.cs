using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Services.IServices
{
    public interface IProductTypeService : IService<ProductType, Guid>, IValidateService<ProductType>,
        IFilterService<ProductType>
    {
    }
}