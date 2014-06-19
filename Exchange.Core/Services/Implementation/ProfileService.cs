using System.Linq;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;

namespace Exchange.Core.Services.Implementation
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        #region Profile Implementation

        public Profiles GetProfileByUserId(Guid userId, bool isAnonymous)
        {
            return _profileRepository.GetProfileByUserId(userId, isAnonymous);
        }

        public Profiles GetProfileByUserId(Guid userId)
        {
            return _profileRepository.GetProfileByUserId(userId);
        }

        public Profiles Get(Guid key)
        {
            return _profileRepository.Get(key);
        }

        public void Save(Profiles entity)
        {
            _profileRepository.Save(entity);
        }

        public void SaveOrUpdate(Profiles entity)
        {
            _profileRepository.SaveOrUpdate(entity);
        }

        public void SaveChanges(Profiles entity)
        {
            _profileRepository.SaveChanges(entity);
        }

        public void Delete(Profiles entity)
        {
            _profileRepository.Delete(entity);
        }

        #endregion Profile Implementation

        public List<Profiles> GetAllData()
        {
            return _profileRepository.GetAll().ToList();
        }

        public List<Profiles> GetDataWithPaging(int pageIndex, int pageSize, out long total)
        {
            return _profileRepository.GetDataWithPaging(pageIndex, pageSize, out total);
        }

        public List<Profiles> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize,
            out long total)
        {
            return _profileRepository.GetDataWithPagingAndSearch(searchString, pageIndex, pageSize, out total);
        }
    }
}