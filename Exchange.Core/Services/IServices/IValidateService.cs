using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Services.IServices
{
    public interface IValidateService<TEntity>
    {

        bool CheckDataIfExists(TEntity entity);
        bool CheckDataIfExists(string param);
    }
}
