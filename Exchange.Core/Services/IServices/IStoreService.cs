using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;


namespace Exchange.Core.Services.IServices
{
    public interface IStoreService : IService<Store, Guid>, IValidateService<Store>, IFilterService<Store>
    {
      
    }
}
