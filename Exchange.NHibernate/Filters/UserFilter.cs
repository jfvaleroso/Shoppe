using NHibernate.Criterion;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Filters
{
    public class UserFilter
    {
        #region Main Search

        public static List<Order> Orders()
        {
            var orderList = new List<Order>();
            //  orderList.Add(Order.Asc("LastName"));
            return orderList;
        }

        public static Dictionary<string, string> Alias()
        {
            var aliases = new Dictionary<string, string>();
            //   aliases.Add("UserProfile", "profile");
            return aliases;
        }

        public static List<ICriterion> Search(string searchString)
        {
            var criterion = new List<ICriterion>();
            //if (searchString.Length != 1)
            //{
            //    criterion.Add(Restrictions.Or(
            //     NHibernate.Criterion.Restrictions.Like("profile.LastName", searchString, MatchMode.Anywhere),
            //     NHibernate.Criterion.Restrictions.Like("profile.FirstName", searchString, MatchMode.Anywhere)
            //     ));
            //}
            //else
            //{
            //    criterion.Add(Restrictions.Like("profile.LastName", searchString, MatchMode.Start));
            //}
            return criterion;
        }

        #endregion Main Search
    }
}