using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;
using Exchange.Web.Models;
using Exchange.Core.Services.Implementation;

using Exchange.Provider.Profile;

namespace Exchange.Web.Controllers
{
    public class HomeController : Controller
    {

        //private readonly IProductService productService;
        //private readonly IUserService userService;
        //private readonly IProfileService profileService;
        //private readonly IRoleService roleService;
        //private readonly NHMembershipProvider membershipProvider;
        //private readonly NHProfileProvider profileProvider;
        //private readonly NHRoleProvider roleProvider;
        //private readonly UserProfileBase userProfileBase;
       
        public HomeController(IProductService productService)
        {
            //this.userService = userService;
            //this.productService = productService;
            //this.membershipProvider = Exchange.Web.Helper.Provider.membershipProvider;
            //this.profileProvider = Exchange.Web.Helper.Provider.profileProvider;
            //this.userProfileBase = Exchange.Web.Helper.Provider.userProfileBase;
            //this.roleProvider = Exchange.Web.Helper.Provider.roleProvider;
          
           
        }

        public ActionResult Index3()
        {
            ProductModel model = new ProductModel();
           // model.ProductList = productService.GetAll();
       
            return View(model);
        }

        public ActionResult Index()
        {

            //ViewBag.FirstName = Profile.LastActivityDate.ToString();
            return View();
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
