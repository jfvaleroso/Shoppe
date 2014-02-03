using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Services.IServices;
using Exchange.Core.Repositories;
using Exchange.Core.Entities;

namespace Exchange.Core.Services.Implementation
{
    public class ProfileService: IProfileService
    {
        private readonly IProfileRepository profileRepository;
        public ProfileService(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        #region Profile Implementation
        public Profiles GetProfileByUserId(int userId, bool isAnonymous)
        {
          return this.profileRepository.GetProfileByUserId(userId, isAnonymous);
        }
        public Profiles GetProfileByUserId(int userId)
        {
            return this.profileRepository.GetProfileByUserId(userId);
        }   
        public Profiles Get(int key)
        {
            return this.profileRepository.Get(key);
        }
        public void Save(Profiles entity)
        {
            this.profileRepository.Save(entity);
        }
        public void SaveOrUpdate(Profiles entity)
        {
            this.profileRepository.SaveOrUpdate(entity);
        }
        public void SaveChanges(Profiles entity)
        {
            this.profileRepository.SaveChanges(entity);
        }
        public void Delete(Profiles entity)
        {
            this.profileRepository.Delete(entity);
        }
        #endregion



        public List<Profiles> GetDataWithPaging(int pageIndex, int pageSize, out long total)
        {
            return this.profileRepository.GetDataWithPaging(pageIndex, pageSize, out total);
        }

        public List<Profiles> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return this.profileRepository.GetDataWithPagingAndSearch(searchString, pageIndex, pageSize, out total);
        }
    }
}
