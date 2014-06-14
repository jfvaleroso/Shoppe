using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Exchange.NHibernateBase.Filters
{
    public class InvoiceFilter
    {
        #region Main Search

        public static List<Order> Orders()
        {
            var orderList = new List<Order>();
            return orderList;
        }

        public static Dictionary<string, string> AliasByStore()
        {
            var aliases = new Dictionary<string, string>();
            aliases.Add("Store", "s");
            return aliases;
        }

        public static List<ICriterion> SearchByStore(Guid storeId)
        {
            var criterion = new List<ICriterion>();
            criterion.Add(Restrictions.Eq("s.Id", storeId));
            return criterion;
        }

        #endregion Main Search
    }
}