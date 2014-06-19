using Exchange.Core.Entities;
using System;
using System.Collections.Generic;

namespace Exchange.Core.Services.IServices
{
    public interface IProfileService
    {
        #region Profile

        Profiles GetProfileByUserId(Guid userId, bool isAnonymous);

        Profiles GetProfileByUserId(Guid userId);

        Profiles Get(Guid key);

        void Save(Profiles enitity);

        void SaveChanges(Profiles enitity);

        void SaveOrUpdate(Profiles entity);

        void Delete(Profiles entity);
        List<Profiles> GetAllData();

        List<Profiles> GetDataWithPaging(int pageIndex, int pageSize, out long total);

        List<Profiles> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total);

        #endregion Profile
    }
}