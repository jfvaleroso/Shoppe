using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.NHibernateBase.Filters
{
    public class StatusFilter
    {
 
            #region Main Search
            public static List<Order> Orders()
            {
                List<Order> orderList = new List<Order>();
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
                criterion.Add(Restrictions.Like("Name", searchString, MatchMode.Start));
                return criterion;
            }

            #endregion
        
    }
}
