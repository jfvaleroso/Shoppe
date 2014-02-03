using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Test
{
    public interface ITest<T> 
    {
         IQueryable<T> GetAll();
    }
}
