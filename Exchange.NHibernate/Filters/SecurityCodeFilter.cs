using NHibernate.Criterion;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Filters
{
    public class SecurityCodeFilter
    {
        #region Main Search

        public static List<Order> Orders()
        {
            var orderList = new List<Order>();
            //orderList.Add(Order.Asc("LastName"));
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
            criterion.Add(Restrictions.Like("PassCode", searchString, MatchMode.Start));
            return criterion;
        }

        public static List<ICriterion> SearchByCode(string searchString)
        {
            var criterion = new List<ICriterion>();
            criterion.Add(Restrictions.Eq("PassCode", searchString));
            return criterion;
        }

        #endregion Main Search
    }
}