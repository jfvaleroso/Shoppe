using Exchange.Core.Services.IServices;
using Exchange.Web.Models;
using System.Web.Mvc;

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
            //userService = userService;
            //productService = productService;
            //membershipProvider = Exchange.Web.Helper.Provider.membershipProvider;
            //profileProvider = Exchange.Web.Helper.Provider.profileProvider;
            //userProfileBase = Exchange.Web.Helper.Provider.userProfileBase;
            //roleProvider = Exchange.Web.Helper.Provider.roleProvider;
        }

        public ActionResult Index3()
        {
            var model = new ProductModel();
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