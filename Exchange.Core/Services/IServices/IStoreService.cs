using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Services.IServices
{
    public interface IStoreService : IService<Store, Guid>, IValidateService<Store>, IFilterService<Store>
    {
    }
}