using System.Web.Profile;
using Exchange.Configuration;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Providers;
using Exchange.Web.Models;
using System.Linq;
using System.Web;

namespace Exchange.Web.Helper
{
    public class Common
    {
        private readonly IUserService _userService;

        public Common(IUserService userService)
        {
            _userService = userService;
        }

        public Common()
        {
        }

        public static string GetCurrentUser()
        {
            var profile = HttpContext.Current.Profile as UserProfileBase;
            return profile == null ? string.Empty : Base.GenerateFullName(profile.FirstName, profile.FirstName, profile.LastName);
        }

        public ProfileModel GetCurrentUserProfile()
        {
            var user = HttpContext.Current.Profile as UserProfileBase;
            if (user == null) return new ProfileModel();
            var profile = new ProfileModel
            {
                Name = Base.GenerateFullName(user.FirstName, user.FirstName, user.LastName),
                UserId = user.UserId.ToString()
            };
            return profile;
        }

        public StoreModel GetCurrentUserStoreAccess()
        {
            Users user = _userService.GetUserByUsernameApplicationName(HttpContext.Current.User.Identity.Name,
                ConfigManager.Exchange.ApplicationName);
            var model = new StoreModel();
            model.Id = user.Stores.Select(x => x.Id).FirstOrDefault().ToString();
            model.StoreName = user.Stores.Select(x => x.Name).FirstOrDefault();
            model.StoreCode = user.Stores.Select(x => x.Code).FirstOrDefault();
            return model;
        }
    }
}