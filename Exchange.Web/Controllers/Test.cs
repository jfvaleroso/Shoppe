using Exchange.Core.Services.IServices;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class Test
    {
        private readonly IUserService _userService;

        public Test(IUserService userService)
        {
            _userService = repository;
        }

        private IUserService repository
        {
            get { return DependencyResolver.Current.GetService<IUserService>(); }
        }
    }
}