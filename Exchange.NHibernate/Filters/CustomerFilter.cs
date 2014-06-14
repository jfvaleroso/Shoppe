using NHibernate.Criterion;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Filters
{
    public class CustomerFilter
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
            if (searchString.Length != 1)
            {
                criterion.Add(Restrictions.Or(
                    Restrictions.Like("LastName", searchString, MatchMode.Anywhere),
                    Restrictions.Like("FirstName", searchString, MatchMode.Anywhere)
                    ));
            }
            else
            {
                criterion.Add(Restrictions.Like("LastName", searchString, MatchMode.Start));
            }
            return criterion;
        }

        #endregion Main Search
    }
}