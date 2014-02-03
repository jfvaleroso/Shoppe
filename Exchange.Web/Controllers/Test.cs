using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exchange.Core.Services.IServices;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class Test
    {
        private readonly IUserService userService;
        private  IUserService repository { get { return DependencyResolver.Current.GetService<IUserService>(); } }
        public Test(IUserService userService)
        {
            this.userService = repository;
        }
    }
}