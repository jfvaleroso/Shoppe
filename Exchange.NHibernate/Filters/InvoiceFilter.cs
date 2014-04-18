using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Filters
{
    public class InvoiceFilter
    {
        #region Main Search
        public static List<Order> Orders()
        {
            List<Order> orderList = new List<Order>();
            return orderList;
        }
        public static Dictionary<string, string> AliasByStore()
        {
            Dictionary<string, string> aliases = new Dictionary<string, string>();
            aliases.Add("Store", "s");
            return aliases;
        }
        public static List<ICriterion> SearchByStore(Guid storeId)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            criterion.Add(Restrictions.Eq("s.Id", storeId));
            return criterion;
        }

        #endregion
    }
}
