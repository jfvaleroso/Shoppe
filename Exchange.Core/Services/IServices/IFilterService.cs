using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Services.IServices
{
    public interface IFilterService<TEntity> 
    {
        List<TEntity> GetDataListByStatus(bool active);
    }
}
