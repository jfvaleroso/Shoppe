using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Helper.Common;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHActivityLogsRepository : NHRepositoryBase<ActivityLogs, Guid>, IActivityLogsRepository
    {
        public List<ActivityLogs> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize,
            out long total)
        {
            var criterion = new List<ICriterion>();
            criterion.Add(Restrictions.Or(
                Restrictions.Like("Description", Base.SearchString(searchString)),
                Restrictions.Like("ExecutedBy", Base.SearchString(searchString))
                ));
            return GetDataWithPagingAndSearch(criterion, searchString, pageIndex, pageSize, out total);
        }
    }
}