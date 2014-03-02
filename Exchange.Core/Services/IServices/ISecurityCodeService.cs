using Exchange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Services.IServices
{
    public interface ISecurityCodeService : IService<SecurityCode, long>
    {
        SecurityCode GetDataByCode(string searchString);
    }
}
