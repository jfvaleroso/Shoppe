using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.UnitOfWork
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute : Attribute
    {

    }
}
