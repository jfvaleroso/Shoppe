using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Services.IServices
{
    public interface IProductService : IService<Product, Guid>, IValidateService<Product>, IFilterService<Product>
    {
    }
}