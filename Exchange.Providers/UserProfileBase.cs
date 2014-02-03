using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using Exchange.Core.Repositories;
using Exchange.Core.Services.IServices;
using System.Web.Security;
using System.Web.Mvc;


namespace Exchange.Providers
{
    public class UserProfileBase : System.Web.Profile.ProfileBase
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly NHProfileProvider profileProvider;
        public UserProfileBase()
            : this(DependencyResolver.Current.GetService<IUserService>(), DependencyResolver.Current.GetService<IProfileService>())
        {
        }
        public UserProfileBase(IUserService userService, IProfileService profileService)
        {
            this.userService = userService;
            this.profileService= profileService;
            this.profileProvider = new NHProfileProvider();
        }

      

        public static UserProfileBase GetUserProfile(string username)
        {
            ProfileBase profileBase = (ProfileBase)Create(username, true);
            return profileBase as UserProfileBase;
        }
        public static UserProfileBase GetUserProfile()
        {
            return Create(Membership.GetUser().UserName) as UserProfileBase;
        }

        


        #region profile
        [SettingsAllowAnonymous(false)]
        public string FirstName
        {
            get { return base["FirstName"] as string; }

            set { base["FirstName"] = value; }
        }
        [SettingsAllowAnonymous(false)]
        public string LastName
        {
            get { return base["LastName"] as string; }

            set { base["LastName"] = value; }
        }
        [SettingsAllowAnonymous(false)]
        public string Gender
        {
            get { return base["Gender"] as string; }

            set { base["Gender"] = value; }
        }
        [SettingsAllowAnonymous(false)]
        public DateTime BirthDate
        {
            get { return (DateTime)base["BirthDate"]; }

            set { base["BirthDate"] = value; }
        }
        [SettingsAllowAnonymous(false)]
        public string Position
        {
            get { return base["Position"] as string; }

            set { base["Position"] = value; }
        }
        [SettingsAllowAnonymous(false)]
        public string Address
        {
            get { return base["Address"] as string; }

            set { base["Address"] = value; }
        }
        [SettingsAllowAnonymous(false)]
        public string Subscription
        {

            get { return base["Subscription"] as string; }

            set { base["Subscription"] = value; }

        }
        [SettingsAllowAnonymous(false)]
        public string Language
        {

            get { return base["Language"] as string; }

            set { base["Language"] = value; }

        }
        #endregion
    }
}