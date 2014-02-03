using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Test
{
    public class Test<T>: ITest<T> 
    {

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
