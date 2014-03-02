using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Filters
{
    public class SecurityCodeFilter
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
                criterion.Add(Restrictions.Like("PassCode", searchString, MatchMode.Start));
                return criterion;
            }
            public static List<ICriterion> SearchByCode(string searchString)
            {
                List<ICriterion> criterion = new List<ICriterion>();
                criterion.Add(Restrictions.Eq("PassCode", searchString));
                return criterion;
            }

            #endregion
        
    }
}
