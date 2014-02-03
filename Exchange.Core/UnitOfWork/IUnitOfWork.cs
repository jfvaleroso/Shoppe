using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Opens database connection and begins transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commits transaction and closes database connection.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks transaction and closes database connection.
        /// </summary>
        void Rollback();
    }
}
