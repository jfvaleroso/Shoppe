using System.Collections.Generic;

namespace Exchange.Core.Repositories
{
    public interface ISearchRepository<TEntity>
    {
        List<TEntity> GetDataWithPagingAndSearch(string searchString, int pagNumber, int pageSize, out long total);
    }
}