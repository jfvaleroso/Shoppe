using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http;
using System.Web.Mvc;

//using InfoSMS.adre.directory;

namespace Exchange.Web.Dependency
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                //All MVC controllers
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient(),
                Classes.FromAssemblyNamed("Elmah.Mvc").BasedOn<IController>().LifestyleTransient(),
                //test jeff api controrller register
                AllTypes.FromThisAssembly().BasedOn<ApiController>().LifestyleScoped(),
                //all action filter
                AllTypes.FromThisAssembly().BasedOn<ActionFilterAttribute>().LifestyleScoped()
                );
        }
    }
}