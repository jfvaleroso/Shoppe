using NHibernate.Criterion;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Filters
{
    public class ProductTypeFilter
    {
        public static List<ICriterion> Search(string searchString)
        {
            var criterion = new List<ICriterion>();
            criterion.Add(Restrictions.Or(
                Restrictions.Like("Code", searchString, MatchMode.Anywhere),
                Restrictions.Like("Name", searchString, MatchMode.Anywhere)
                ));
            return criterion;
        }
    }
}