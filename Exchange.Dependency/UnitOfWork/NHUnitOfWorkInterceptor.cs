using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Exchange.NHibernateBase.Repositories;
using System.Reflection;
using Castle.DynamicProxy;
using System.Configuration;



namespace Exchange.Dependency.UnitOfWork
{
    public class NHUnitOfWorkInterceptor : Castle.DynamicProxy.IInterceptor, IDisposable
    {
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Creates a new NHUnitOfWorkInterceptor object.
        /// </summary>
        /// <param name="sessionFactory">Nhibernate session factory.</param>
        public NHUnitOfWorkInterceptor(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Intercepts a method.
        /// </summary>
        /// <param name="invocation">Method invocation arguments</param>
        public void Intercept(IInvocation invocation)
        {

            if (!RequiresDbConnection(invocation.MethodInvocationTarget))
            {
                invocation.Proceed();
                return;
            }

            try
            {


                if (NHUnitOfWork.Current == null)
                {
                    NHUnitOfWork.Current = new NHUnitOfWork(_sessionFactory);
                }

                NHUnitOfWork.Current.BeginTransaction();

                try
                {
                    invocation.Proceed();
                    NHUnitOfWork.Current.Commit();
                }
                catch
                {
                    try
                    {
                        NHUnitOfWork.Current.Rollback();
                    }
                    catch
                    {

                    }

                    throw;
                }
            }
            finally
            {
              // NHUnitOfWork.Current = null;
            }
        }

        public void Dispose()
        {
            if (NHUnitOfWork.Current != null)
            {
                NHUnitOfWork.Current.Dispose();
                NHUnitOfWork.Current = null;
            }
            
            
        }

        private static bool RequiresDbConnection(MethodInfo methodInfo)
        {
            if (UnitOfWorkHelper.HasUnitOfWorkAttribute(methodInfo))
            {
                return true;
            }

            if (UnitOfWorkHelper.IsRepositoryMethod(methodInfo))
            {
                return true;
            }

            if (UnitOfWorkHelper.IsProviderMethod(methodInfo))
            {
                return true;
            }



            return false;
        }

      
    }
}
