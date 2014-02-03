using Exchange.Helper;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Filters
{
    public class CustomerFilter
    {
        #region Main Search
        public static List<Order> Orders()
        {
            List<Order> orderList = new List<Order>();
           //orderList.Add(Order.Asc("LastName"));
            return orderList;
        }
        public static Dictionary<string, string> Alias()
        {
            Dictionary<string, string> aliases = new Dictionary<string, string>();
            return aliases;
        }
        public static List<ICriterion> Search(string searchString)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            if (searchString.Length != 1)
            {
                criterion.Add(Restrictions.Or(
                 NHibernate.Criterion.Restrictions.Like("LastName", searchString, MatchMode.Anywhere),
                 NHibernate.Criterion.Restrictions.Like("FirstName", searchString, MatchMode.Anywhere)
                 ));
            }
            else
            {
                criterion.Add(Restrictions.Like("LastName", searchString, MatchMode.Start));
            }
            return criterion;
        }

        #endregion
    }
}
