using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Filters
{
    public class ProductFilter
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

        public static List<ICriterion> Test()
        {
            List<ICriterion> criterion = new List<ICriterion>();
            return criterion;
        }
        public static List<Order> OrdersTest()
        {
            List<Order> orderList = new List<Order>();
            orderList.Add(Order.Asc("p.Code"));
            return orderList;
        }

        public static Dictionary<string, string> AliasTest()
        {
            Dictionary<string, string> aliases = new Dictionary<string, string>();
            aliases.Add("ProductType", "p");
            return aliases;
        }
    }
}
