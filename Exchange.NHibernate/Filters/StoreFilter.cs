using NHibernate.Criterion;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Filters
{
    public class StoreFilter
    {
        #region Main Search

        public static List<Order> Orders()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc("Name"));
            return orderList;
        }

        public static Dictionary<string, string> Alias()
        {
            var aliases = new Dictionary<string, string>();
            return aliases;
        }

        public static List<ICriterion> Search(string searchString)
        {
            var criterion = new List<ICriterion>();
            criterion.Add(Restrictions.Or(
                Restrictions.Like("Code", searchString, MatchMode.Anywhere),
                Restrictions.Like("Name", searchString, MatchMode.Anywhere)
                ));
            return criterion;
        }

        #endregion Main Search
    }
}