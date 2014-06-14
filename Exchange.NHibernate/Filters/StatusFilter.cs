using NHibernate.Criterion;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Filters
{
    public class StatusFilter
    {
        #region Main Search

        public static List<Order> Orders()
        {
            var orderList = new List<Order>();
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
            criterion.Add(Restrictions.Like("Name", searchString, MatchMode.Start));
            return criterion;
        }

        #endregion Main Search
    }
}