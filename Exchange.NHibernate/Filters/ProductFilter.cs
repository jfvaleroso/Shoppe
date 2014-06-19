using System;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Filters
{
    public class ProductFilter
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

        public static List<ICriterion> SearchById(string id)
        {
            var criterion = new List<ICriterion> {Restrictions.Eq("Id", new Guid(id))};
            return criterion;
        }

        public static List<ICriterion> Test()
        {
            var criterion = new List<ICriterion>();
            return criterion;
        }

        public static List<Order> OrdersTest()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc("p.Code"));
            return orderList;
        }

        public static Dictionary<string, string> AliasTest()
        {
            var aliases = new Dictionary<string, string>();
            aliases.Add("ProductType", "p");
            return aliases;
        }
    }
}