using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;

namespace Exchange.Core.Services.IServices
{
    public interface IProfileService 
    {

        #region Profile
        Profiles GetProfileByUserId(int userId, bool isAnonymous);
        Profiles GetProfileByUserId(int userId);
        Profiles Get(int key);
        void Save(Profiles enitity);
        void SaveChanges(Profiles enitity);
        void SaveOrUpdate(Profiles entity);
        void Delete(Profiles entity);
        List<Profiles> GetDataWithPaging(int pageIndex, int pageSize, out long total);
        List<Profiles> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total);
        #endregion

    }
}
