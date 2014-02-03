using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Repositories;
using Exchange.Core.Entities;

namespace Exchange.Core.Services.IServices
{
    public  interface IRoleService :IService<Roles, int>, IValidateService<Roles>
    {
    }
}
