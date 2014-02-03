using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Filters
{
    public class ProductHistoryFilter
    {

        #region Main Search
        public static List<Order> Orders()
        {
            List<Order> orderList = new List<Order>();
            orderList.Add(Order.Desc("DateModified"));
            return orderList;
        }
        public static Dictionary<string, string> Alias()
        {
            Dictionary<string, string> aliases = new Dictionary<string, string>();
            aliases.Add("Product", "p");
            return aliases;
        }
        public static List<ICriterion> Search(string id)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            criterion.Add(NHibernate.Criterion.Restrictions.Eq("p.Id", Convert.ToInt32(id)));
            return criterion;
        }

        #endregion


    }
}
