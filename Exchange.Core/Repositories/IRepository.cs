using Exchange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Exchange.Core.Repositories
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : Entity<TPrimaryKey>
    {
        #region Filter

        TEntity Get(TPrimaryKey key);

        TEntity GetByExpression(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        List<TEntity> GetDataWithPaging(int pageNumber, int pageSize, out long total);

        #endregion Filter

        #region CRUD Method

        void Save(TEntity entity);

        TPrimaryKey Create(TEntity entity);

        void SaveOrUpdate(TEntity entity);

        void SaveChanges(TEntity entity);

        void Delete(TPrimaryKey id);

        void Delete(TEntity entity);

        IEnumerable<TEntity> SaveOrUpdateAll(params TEntity[] entities);

        #endregion CRUD Method
    }
}