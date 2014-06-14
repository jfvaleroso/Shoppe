using Exchange.Core.UnitOfWork;
using NHibernate;
using System;

namespace Exchange.NHibernateBase.Repositories
{
    public class NHUnitOfWork : IUnitOfWork
    {
        /// <summary>
        ///     Gets current instance of the NhUnitOfWork.
        ///     It gets the right instance that is related to current thread.
        /// </summary>
        [ThreadStatic]
        private static NHUnitOfWork _current;

        /// <summary>
        ///     Reference to the session factory.
        /// </summary>
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        ///     Reference to the currently running transcation.
        /// </summary>
        private ITransaction _transaction;

        /// <summary>
        ///     Creates a new instance of NhUnitOfWork.
        /// </summary>
        /// <param name="sessionFactory"></param>
        public NHUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            Session = _sessionFactory.OpenSession();
        }

        public static NHUnitOfWork Current
        {
            get { return _current; }
            set { _current = value; }
        }

        /// <summary>
        ///     Gets Nhibernate session object to perform queries.
        /// </summary>
        public ISession Session { get; private set; }

        /// <summary>
        ///     Opens database connection and begins transaction.
        /// </summary>
        public void BeginTransaction()
        {
            //Session = _sessionFactory.OpenSession();
            //_transaction = Session.BeginTransaction();
            if (_transaction == null)
            {
                _transaction = Session.BeginTransaction();
            }
            else
            {
                if (!_transaction.IsActive)
                    _transaction = Session.BeginTransaction();
            }
        }

        /// <summary>
        ///     Commits transaction and closes database connection.
        /// </summary>
        public void Commit()
        {
            try
            {
                if (_transaction.IsActive)
                    _transaction.Commit();
            }
            finally
            {
            }
        }

        /// <summary>
        ///     Rollbacks transaction and closes database connection.
        /// </summary>
        public void Rollback()
        {
            try
            {
                if (_transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
            }
        }

        public void Dispose()
        {
            Session.Close();
        }
    }
}