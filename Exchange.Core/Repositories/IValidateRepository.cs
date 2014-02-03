using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Repositories
{
    public interface IValidateRepository<TEntity>
    {
        List<TEntity> CheckIfDataExists(Dictionary<string, object> parameter);
        List<TEntity> GetFilteredData(Dictionary<string, object> parameter);
    }
}
