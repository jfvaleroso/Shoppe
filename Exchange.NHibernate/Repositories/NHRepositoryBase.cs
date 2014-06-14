using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Exchange.NHibernateBase.Repositories
{
    public abstract class NHRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
    {
        #region Session

        protected ISession Session
        {
            get { return NHUnitOfWork.Current.Session; }
        }

        #endregion Session

        #region Common CRUD Method

        public void Save(TEntity entity)
        {
            Session.Save(entity);
        }

        public TPrimaryKey Create(TEntity entity)
        {
            var Id = (TPrimaryKey)Session.Save(entity);
            return Id;
        }

        public void SaveOrUpdate(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public void SaveChanges(TEntity entity)
        {
            Session.Update(entity);
        }

        public void Delete(TPrimaryKey id)
        {
            Session.Delete(Session.Load<TEntity>(id));
        }

        public void Delete(TEntity entity)
        {
            Session.Delete(entity);
        }

        public IEnumerable<TEntity> SaveOrUpdateAll(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        #endregion Common CRUD Method

        #region Filter

        public TEntity Get(TPrimaryKey key)
        {
            return Session.Get<TEntity>(key);
        }

        public TEntity GetByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return Session.Query<TEntity>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Session.Query<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        #endregion Filter

        #region Search

        public List<TEntity> GetDataWithPaging(int pageIndex, int pageSize, out long total)
        {
            total = Session.CreateCriteria<TEntity>()
                .SetProjection(Projections.RowCount())
                .FutureValue<Int32>().Value;
            List<TEntity> results = Session.CreateCriteria<TEntity>()
                .SetFirstResult((pageIndex - 1) * pageSize)
                .SetMaxResults(pageSize)
                .Future<TEntity>()
                .ToList<TEntity>();
            return results.ToList();
        }

        public List<TEntity> GetDataWithPagingAndSearch(List<ICriterion> criterion, string searchString, int pageIndex,
            int pageSize, out long total)
        {
            ICriteria session = Session.CreateCriteria<TEntity>();
            foreach (ICriterion criteria in criterion)
            {
                session.Add(criteria);
            }

            total = GetTotalCount(criterion);
            List<TEntity> results = session
                .SetFirstResult((pageIndex - 1) * pageSize)
                .SetMaxResults(pageSize)
                .Future<TEntity>()
                .ToList<TEntity>();
            return results;
        }

        public List<TEntity> GetDataWithPagingAndSearch(List<ICriterion> criterion, Dictionary<string, string> aliases,
            List<Order> orders, int pageIndex, int pageSize, out long total)
        {
            ICriteria session = Session.CreateCriteria<TEntity>();
            //alias
            if (aliases != null)
            {
                foreach (var alias in aliases)
                {
                    session.CreateAlias(alias.Key, alias.Value);
                }
            }
            //filter
            if (criterion != null)
            {
                foreach (ICriterion criteria in criterion)
                {
                    session.Add(criteria);
                }
            }
            //orders
            if (orders != null)
            {
                foreach (Order order in orders)
                {
                    session.AddOrder(order);
                }
            }
            total = GetTotalCount(criterion, aliases, orders);
            List<TEntity> results = session
                .SetFirstResult((pageIndex - 1) * pageSize)
                .SetMaxResults(pageSize)
                .Future<TEntity>()
                .ToList<TEntity>();
            return results;
        }

        public long GetTotalCount(List<ICriterion> criterion, Dictionary<string, string> aliases, List<Order> orders)
        {
            ICriteria session = Session.CreateCriteria<TEntity>();
            //alias
            if (aliases != null)
            {
                foreach (var alias in aliases)
                {
                    session.CreateAlias(alias.Key, alias.Value);
                }
            }
            //filter
            if (criterion != null)
            {
                foreach (ICriterion criteria in criterion)
                {
                    session.Add(criteria);
                }
            }
            //orders
            //if (orders != null)
            //{
            //    foreach (var order in orders)
            //    { session.AddOrder(order); }
            //}
            long total = session.SetProjection(Projections.Count(Projections.Id())).FutureValue<int>().Value;
            return total;
        }

        public long GetTotalCount(List<ICriterion> criterion)
        {
            ICriteria session = Session.CreateCriteria<TEntity>();
            foreach (ICriterion criteria in criterion)
            {
                session.Add(criteria);
            }
            long total = session.SetProjection(Projections.Count(Projections.Id())).FutureValue<int>().Value;
            return total;
        }

        public List<TEntity> CheckIfDataExists(Dictionary<string, object> parameter)
        {
            DetachedCriteria criteria = DetachedCriteria.For<TEntity>();
            foreach (var item in parameter)
            {
                criteria.Add(
                    Restrictions.Eq(item.Key, item.Value)
                    );
            }
            return FindAll(criteria).ToList();
        }

        public List<TEntity> GetFilteredData(Dictionary<string, object> parameter)
        {
            DetachedCriteria criteria = DetachedCriteria.For<TEntity>();
            foreach (var item in parameter)
            {
                criteria.Add(
                    Restrictions.Eq(item.Key, item.Value)
                    );
            }
            return FindAll(criteria).ToList();
        }

        public TEntity GetFilteredDataByParameter(List<ICriterion> criterion)
        {
            ICriteria session = Session.CreateCriteria<TEntity>();
            if (criterion != null)
            {
                foreach (ICriterion criteria in criterion)
                {
                    session.Add(criteria);
                }
            }
            var result = session.UniqueResult<TEntity>();
            return result;
        }

        public List<TEntity> Test(List<ICriterion> criterion, Dictionary<string, string> aliases, List<Order> orders)
        {
            ICriteria session = Session.CreateCriteria<TEntity>();
            //alias
            if (aliases != null)
            {
                foreach (var alias in aliases)
                {
                    session.CreateAlias(alias.Key, alias.Value);
                }
            }
            if (criterion != null)
            {
                foreach (ICriterion criteria in criterion)
                {
                    session.Add(criteria);
                }
            }
            //orders
            if (orders != null)
            {
                foreach (Order order in orders)
                {
                    session.AddOrder(order);
                }
            }
            List<TEntity> results = session
                .Future<TEntity>()
                .ToList<TEntity>();
            return results;
        }

        #endregion Search

        #region Optimized Search

        public IEnumerable<TEntity> FindAll(DetachedCriteria criteria)
        {
            return criteria.GetExecutableCriteria(Session).List<TEntity>();
        }

        public IEnumerable<TEntity> FindAll(DetachedCriteria criteria, params Order[] orders)
        {
            if (orders != null)
            {
                foreach (Order order in orders)
                {
                    criteria.AddOrder(order);
                }
            }

            return FindAll(criteria);
        }

        public IEnumerable<TEntity> FindAll(DetachedCriteria criteria, int firstResult, int numberOfResults,
            params Order[] orders)
        {
            criteria.SetFirstResult(firstResult).SetMaxResults(numberOfResults);
            return FindAll(criteria, orders);
        }

        public TEntity FindOne(DetachedCriteria criteria)
        {
            return criteria.GetExecutableCriteria(Session).UniqueResult<TEntity>();
        }

        public TEntity FindFirst(DetachedCriteria criteria)
        {
            IList<TEntity> results = criteria.SetFirstResult(0).SetMaxResults(1)
                .GetExecutableCriteria(Session).List<TEntity>();

            if (results.Count > 0)
            {
                return results[0];
            }

            return default(TEntity);
        }

        public TEntity FindFirst(DetachedCriteria criteria, Order order)
        {
            return FindFirst(criteria.AddOrder(order));
        }

        public long Count(DetachedCriteria criteria)
        {
            return Convert.ToInt64(criteria.GetExecutableCriteria(Session)
                .SetProjection(Projections.RowCountInt64()).UniqueResult());
        }

        public bool Exists(DetachedCriteria criteria)
        {
            return Count(criteria) > 0;
        }

        #endregion Optimized Search
    }
}