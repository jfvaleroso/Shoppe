using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;

namespace Exchange.Core.Services.Implementation
{
    public class ActivityLogsService: IActivityLogsService
    {
        private readonly IActivityLogsRepository activityLogsRepository;
        public ActivityLogsService(IActivityLogsRepository activityLogsRepository)
        {
            this.activityLogsRepository = activityLogsRepository;
        }

        public ActivityLogs GetDataById(Guid id)
        {
            return this.activityLogsRepository.Get(id);
        }

        public ActivityLogs GetByExpression(ActivityLogs entity)
        {
          return  this.activityLogsRepository.GetByExpression(x => x.Type.Equals(entity.Type));
        }
        public List<ActivityLogs> GetAllData()
        {
            return this.activityLogsRepository.GetAll().ToList();
        }
        public List<ActivityLogs> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.activityLogsRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<ActivityLogs> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.activityLogsRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        public void Save(ActivityLogs entity)
        {
            this.activityLogsRepository.Save(entity);
        }

        public Guid Create(ActivityLogs entity)
        {
            return this.activityLogsRepository.Create(entity);
        }

        public void CreateAuditLog(string userName, string ipAddress, string areaAccessed,  DateTime timeAccessed, string action, string result )
        {
            ActivityLogs entity = new ActivityLogs();
            entity.Description = string.Format("IP Address: {0}, Area Access: {1}, Result: {2}", ipAddress, areaAccessed, result);
            entity.ExecutedBy = userName;
            entity.Timestamp = timeAccessed;
            entity.Type = action;
            this.activityLogsRepository.Create(entity);
        }

        public void SaveChanges(ActivityLogs entity)
        {
            this.activityLogsRepository.SaveChanges(entity);
        }

        public void SaveOrUpdate(ActivityLogs entity)
        {
            this.activityLogsRepository.SaveOrUpdate(entity);
        }

        public bool Delete(Guid id)
        {
            try
            {
                this.activityLogsRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
    }
}
