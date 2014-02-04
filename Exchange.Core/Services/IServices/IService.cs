using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Exchange.Core.Services.IServices
{
    public interface IService<TEntity, TPrimaryKey>
    {
        TEntity GetDataById(TPrimaryKey id);
        TEntity GetByExpression(TEntity entity);
        List<TEntity> GetDataListWithPaging(int pageNumber, int pageSize, out long total);
        List<TEntity> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total);
        List<TEntity> GetAllData();
        void Save(TEntity entity);
        TPrimaryKey Create(TEntity entity);
        void SaveChanges(TEntity entity);
        void SaveOrUpdate(TEntity entity);
        bool Delete(TPrimaryKey id);

    }
}
