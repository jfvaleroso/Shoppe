using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Filters
{
    public class ProductTypeFilter
    {
        public static List<ICriterion> Search(string searchString)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            criterion.Add(Restrictions.Or(
               NHibernate.Criterion.Restrictions.Like("Code", searchString, MatchMode.Anywhere),
               NHibernate.Criterion.Restrictions.Like("Name", searchString, MatchMode.Anywhere)
               ));
            return criterion;
        }
    }
}
