using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using Exchange.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Services.Implementation
{
    public class StatusService : IStatusService
    {
        #region Constructor

        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        #endregion Constructor

        #region CRUD

        public void Save(Status entity)
        {
            _statusRepository.Save(entity);
        }

        public Guid Create(Status entity)
        {
            return _statusRepository.Create(entity);
        }

        public void SaveChanges(Status entity)
        {
            _statusRepository.SaveChanges(entity);
        }

        public void SaveOrUpdate(Status productType)
        {
            _statusRepository.SaveOrUpdate(productType);
        }

        [UnitOfWork]
        public bool Delete(Guid id)
        {
            try
            {
                _statusRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion CRUD

        #region Search and Filter

        public Status GetDataById(Guid id)
        {
            return _statusRepository.Get(id);
        }

        public Status GetByExpression(Status entity)
        {
            return _statusRepository.GetByExpression(x => x.Name.Equals(entity.Name));
        }

        public List<Status> GetAllData()
        {
            return _statusRepository.GetAll().ToList();
        }

        [UnitOfWork]
        public List<Status> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return _statusRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        [UnitOfWork]
        public List<Status> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize,
            out long total)
        {
            return _statusRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        public List<Status> GetDataListByStatus(bool active)
        {
            return _statusRepository.Get(x => x.Active.Equals(active)).ToList();
        }

        #endregion Search and Filter

        #region Validator

        public bool CheckDataIfExists(Status entity)
        {
            var parameter = new Dictionary<string, object>
            {
                {"Name", entity.Name},
                {"Description", entity.Description},
                {"Active", entity.Active}
            };
            List<Status> process = _statusRepository.CheckIfDataExists(parameter);
            return process.Any();
        }

        public bool CheckDataIfExists(string param)
        {
            var parameter = new Dictionary<string, object> { { "Name", param } };
            List<Status> process = _statusRepository.CheckIfDataExists(parameter);
            return process.Any();
        }

        #endregion Validator

        public Status GetStatusByCode(string code)
        {
            return _statusRepository.GetByExpression(x => x.Code.Equals(code));
        }
    }
}