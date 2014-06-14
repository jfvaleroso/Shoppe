using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Filters
{
    public class ProductHistoryFilter
    {
        #region Main Search

        public static List<Order> Orders()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Desc("DateModified"));
            return orderList;
        }

        public static Dictionary<string, string> Alias()
        {
            var aliases = new Dictionary<string, string>();
            aliases.Add("Product", "p");
            return aliases;
        }

        public static List<ICriterion> Search(string id)
        {
            var criterion = new List<ICriterion>();
            criterion.Add(Restrictions.Eq("p.Id", Convert.ToInt32(id)));
            return criterion;
        }

        #endregion Main Search
    }
}