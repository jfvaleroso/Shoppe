﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;

namespace Exchange.Core.Repositories
{
    public interface IProductTypeRepository : IRepository<ProductType, int>, ISearchRepository<ProductType>, IValidateRepository<ProductType>
    {
       
    }
}
