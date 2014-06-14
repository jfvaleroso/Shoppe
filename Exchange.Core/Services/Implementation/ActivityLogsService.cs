using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Services.Implementation
{
    public class ActivityLogsService : IActivityLogsService
    {
        private readonly IActivityLogsRepository _activityLogsRepository;

        public ActivityLogsService(IActivityLogsRepository activityLogsRepository)
        {
            _activityLogsRepository = activityLogsRepository;
        }

        public ActivityLogs GetDataById(Guid id)
        {
            return _activityLogsRepository.Get(id);
        }

        public ActivityLogs GetByExpression(ActivityLogs entity)
        {
            return _activityLogsRepository.GetByExpression(x => x.Type.Equals(entity.Type));
        }

        public List<ActivityLogs> GetAllData()
        {
            return _activityLogsRepository.GetAll().ToList();
        }

        public List<ActivityLogs> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return _activityLogsRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<ActivityLogs> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            return _activityLogsRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        public void Save(ActivityLogs entity)
        {
            _activityLogsRepository.Save(entity);
        }

        public Guid Create(ActivityLogs entity)
        {
            return _activityLogsRepository.Create(entity);
        }

        public void CreateAuditLog(string userName, string ipAddress, string areaAccessed, DateTime timeAccessed,
            string action, string result)
        {
            var entity = new ActivityLogs
            {
                Description =
                    string.Format("IP Address: {0}, Area Access: {1}, Result: {2}", ipAddress, areaAccessed, result),
                ExecutedBy = userName,
                Timestamp = timeAccessed,
                Type = action
            };
            _activityLogsRepository.Create(entity);
        }

        public void SaveChanges(ActivityLogs entity)
        {
            _activityLogsRepository.SaveChanges(entity);
        }

        public void SaveOrUpdate(ActivityLogs entity)
        {
            _activityLogsRepository.SaveOrUpdate(entity);
        }

        public bool Delete(Guid id)
        {
            try
            {
                _activityLogsRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}