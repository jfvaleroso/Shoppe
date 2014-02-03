using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Exchange.Dependency.Installer;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Exchange.Web.Dependency;
using System.Web.Security;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;

using Exchange.Core.Services.Implementation;

namespace Exchange.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        private WindsorContainer _windsorContainer;
        protected void Application_Start()
        {
            InitializeWindsor();
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          

          
            
        }

        protected void Application_End()
        {
            if (_windsorContainer != null)
            {
                _windsorContainer.Dispose();
            }
        }

        private void InitializeWindsor()
        {
            _windsorContainer = new WindsorContainer();
            _windsorContainer.Install(FromAssembly.Containing<DependencyInstaller>());
            _windsorContainer.Install(FromAssembly.This());
            
            //test
            //Exchange.Web.Helper.Provider.membershipProvider = new NHMembershipProvider(_windsorContainer.Resolve<IUserService>());
            //Exchange.Web.Helper.Provider.roleProvider = new NHRoleProvider(_windsorContainer.Resolve<IUserService>(), _windsorContainer.Resolve<IRoleService>());
            //Exchange.Web.Helper.Provider.profileProvider = new NHProfileProvider(_windsorContainer.Resolve<IUserService>(), _windsorContainer.Resolve<IProfileService>());
            //Exchange.Web.Helper.Provider.userProfileBase = new UserProfileBase(_windsorContainer.Resolve<IUserService>(), _windsorContainer.Resolve<IProfileService>());

            

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_windsorContainer.Kernel));
        }
    }
}