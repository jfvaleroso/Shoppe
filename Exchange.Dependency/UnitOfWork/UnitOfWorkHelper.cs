using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Exchange.Core.Repositories;
using Exchange.Core.UnitOfWork;
using System.Web.Security;


namespace Exchange.Dependency.UnitOfWork
{
    public static class UnitOfWorkHelper
    {
        public static bool IsRepositoryMethod(MethodInfo methodInfo)
        {
            return IsRepositoryClass(methodInfo.DeclaringType);
        }

        public static bool IsRepositoryClass(Type type)
        {
            return typeof(IRepository).IsAssignableFrom(type);
        }

        public static bool IsProviderClass(Type type)
        {
            return false;
           // return typeof(NHMembershipProvider).IsAssignableFrom(type);
        }

        public static bool IsProviderMethod(MethodInfo methodInfo)
        {
            return IsProviderClass(methodInfo.DeclaringType);
        }

       
     

        public static bool HasUnitOfWorkAttribute(MethodInfo methodInfo)
        {
            bool hasUOW= methodInfo.IsDefined(typeof(UnitOfWorkAttribute), true);
            return hasUOW;
        }
    }
}
