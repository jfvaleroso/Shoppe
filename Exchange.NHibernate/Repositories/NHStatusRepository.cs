﻿using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.NHibernateBase.Filters;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHStatusRepository : NHRepositoryBase<Status, Guid>, IStatusRepository
    {
        public List<Status> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return GetDataWithPagingAndSearch(StatusFilter.Search(searchString), searchString, pageIndex, pageSize,
                out total);
        }
    }
}