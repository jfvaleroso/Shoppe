using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Test
{
    public class Users
    {
    public string Name { get; set; }
    }

    class Im :ITest<Users>
    {
        public IQueryable<Users> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
