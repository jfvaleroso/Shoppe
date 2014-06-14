using System.Collections.Generic;

namespace Exchange.Core.Services.IServices
{
    public interface IFilterService<TEntity>
    {
        List<TEntity> GetDataListByStatus(bool active);
    }
}