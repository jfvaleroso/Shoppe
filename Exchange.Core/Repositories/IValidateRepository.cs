using System.Collections.Generic;

namespace Exchange.Core.Repositories
{
    public interface IValidateRepository<TEntity>
    {
        List<TEntity> CheckIfDataExists(Dictionary<string, object> parameter);

        List<TEntity> GetFilteredData(Dictionary<string, object> parameter);
    }
}