using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Repositories
{
    public interface IStoreRepository : IRepository<Store, Guid>, ISearchRepository<Store>, IValidateRepository<Store>
    {
    }
}