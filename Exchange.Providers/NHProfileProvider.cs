using Castle.Windsor;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Profile;
using System.Web.Security;

namespace Exchange.Providers
{
    public sealed class NhProfileProvider : ProfileProvider
    {
        private readonly WindsorContainer _container = (WindsorContainer)HttpContext.Current.Application["Windsor"];
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;

        public NhProfileProvider()
        {
            _userService = _container.Resolve<IUserService>();
            _profileService = _container.Resolve<IProfileService>();
        }

        #region private

        private string _applicationName;
        private string connectionString;

        private bool HasInitialized { get; set; }

        #endregion private

        #region Properties

        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        #endregion Properties

        #region Helper Functions

        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }

        #endregion Helper Functions

        #region Private Methods

        private Profiles GetProfile(string username, bool isAuthenticated)
        {
            Profiles profile = null;
            bool isAnonymous = !isAuthenticated;
            try
            {
                Users usr = _userService.GetUserByUsernameApplicationName(username, ApplicationName);

                if (usr != null)
                {
                    profile = _profileService.GetProfileByUserId(usr.Id, isAnonymous);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return profile;
        }

        private Profiles GetProfile(string username)
        {
            Profiles profile = null;

            try
            {
                Users usr = _userService.GetUserByUsernameApplicationName(username, ApplicationName);

                if (usr != null)
                {
                    profile = _profileService.GetProfileByUserId(usr.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return profile;
        }

        private Profiles GetProfile(Guid userId)
        {
            Profiles profile = null;
            try
            {
                Users usr = _userService.GetUserByIdApplicationName(userId, ApplicationName);

                if (usr != null)
                {
                    profile = _profileService.GetProfileByUserId(usr.Id);
                }
                else
                    throw new ProviderException("Membership User does not exist");
            }
            catch (Exception e)
            {
                throw e;
            }

            return profile;
        }

        public Profiles CreateProfile(string username, bool isAnonymous)
        {
            var p = new Profiles();
            var profileCreated = false;
            try
            {
                var usr = _userService.GetUserByUsernameApplicationName(username, ApplicationName);
                if (usr != null) //membership user exits so create a profile
                {
                    var profile = _profileService.GetProfileByUserId(usr.Id);
                    if (profile == null)
                    {
                        p.UserId = usr.Id;
                        p.IsAnonymous = isAnonymous;
                        p.LastUpdatedDate = DateTime.Now;
                        p.LastActivityDate = DateTime.Now;
                        p.ApplicationName = ApplicationName;
                        _profileService.Save(p);
                        profileCreated = true;
                    }
                    p = profile;
                }
                else
                    throw new ProviderException("Membership User does not exist.Profile cannot be created.");
            }
            catch (Exception e)
            {
                throw e;
            }

            if (profileCreated)
                return p;
            return null;
        }

        private bool IsMembershipUser(string username)
        {
            bool hasMembership = false;
            try
            {
                Users usr = _userService.GetUserByUsernameApplicationName(username, ApplicationName);
                if (usr != null) //membership user exits so create a profile
                    hasMembership = true;
            }
            catch (Exception e)
            {
                throw e;
            }

            return hasMembership;
        }

        private bool IsUserInCollection(MembershipUserCollection uc, string username)
        {
            bool isInColl = false;
            foreach (MembershipUser u in uc)
            {
                if (u.UserName.Equals(username))
                    isInColl = true;
            }

            return isInColl;
        }

        private void UpdateActivityDates(string username, bool isAuthenticated, bool activityOnly)
        {
            //Is authenticated and IsAnonmous are opposites,so flip sign,IsAuthenticated = true -> notAnonymous
            bool isAnonymous = !isAuthenticated;
            DateTime activityDate = DateTime.Now;

            Profiles pr = GetProfile(username, isAuthenticated);
            if (pr == null)
                throw new ProviderException("User Profile not found");
            try
            {
                if (activityOnly)
                {
                    pr.LastActivityDate = activityDate;
                    pr.IsAnonymous = isAnonymous;
                }
                else
                {
                    pr.LastActivityDate = activityDate;
                    pr.LastUpdatedDate = activityDate;
                    pr.IsAnonymous = isAnonymous;
                }

                _profileService.SaveChanges(pr);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool DeleteProfile(string username)
        {
            // Check for valid user name.
            if (username == null)
                throw new ArgumentNullException("User name cannot be null.");
            if (username.Contains(","))
                throw new ArgumentException("User name cannot contain a comma (,).");

            Profiles profile = GetProfile(username);
            if (profile == null)
                return false;

            try
            {
                _profileService.Delete(profile);
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        private bool DeleteProfile(Guid id)
        {
            // Check for valid user name.
            Profiles profile = GetProfile(id);
            if (profile == null)
                return false;

            try
            {
                _profileService.Delete(profile);
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        private int DeleteProfilesbyId(string[] ids)
        {
            int deleteCount = 0;
            try
            {
                foreach (string id in ids)
                {
                    if (DeleteProfile(id))
                        deleteCount++;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return deleteCount;
        }

        private void CheckParameters(int pageIndex, int pageSize)
        {
            if (pageIndex < 0)
                throw new ArgumentException("Page index must 0 or greater.");
            if (pageSize < 1)
                throw new ArgumentException("Page size must be greater than 0.");
        }

        private ProfileInfo GetProfileInfoFromProfile(Profiles p)
        {
            Users usr = null;
            usr = _userService.GetUserByIdApplicationName(p.UserId, ApplicationName);
            if (usr == null)
                throw new ProviderException("The userid not found in memebership tables.GetProfileInfoFromProfile(p)");

            // ProfileInfo.Size not currently implemented.
            var pi = new ProfileInfo(usr.Username,
                p.IsAnonymous, p.LastActivityDate, p.LastUpdatedDate, 0);

            return pi;
        }

        #endregion Private Methods

        #region Public Methods

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "ProfileProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sample Fluent Nhibernate Profile provider");
            }
            // Initialize the abstract base class.
            base.Initialize(name, config);

            _applicationName = GetConfigValue(config["applicationName"], HostingEnvironment.ApplicationVirtualPath);

            // Initialize Connection.
            ConnectionStringSettings connectionStringSettings =
                ConfigurationManager.ConnectionStrings[config["connectionStringName"]];
            if (connectionStringSettings == null || connectionStringSettings.ConnectionString.Trim() == "")
                throw new ProviderException("Connection string cannot be blank.");

            connectionString = connectionStringSettings.ConnectionString;
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context,
            SettingsPropertyCollection ppc)
        {
            var username = (string)context["UserName"];
            var isAuthenticated = (bool)context["IsAuthenticated"];
            var profile = GetProfile(username, isAuthenticated);
            // The serializeAs attribute is ignored in this provider implementation.
            var svc = new SettingsPropertyValueCollection();

            if (profile == null)
            {
                if (IsMembershipUser(username))
                    profile = CreateProfile(username, false);
                else
                    throw new ProviderException("Profile cannot be created. There is no membership user");
            }
            foreach (SettingsProperty prop in ppc)
            {
                var pv = new SettingsPropertyValue(prop);
                switch (prop.Name)
                {
                    case "IsAnonymous":
                        pv.PropertyValue = profile.IsAnonymous;
                        break;

                    case "LastActivityDate":
                        pv.PropertyValue = profile.LastActivityDate;
                        break;

                    case "LastUpdatedDate":
                        pv.PropertyValue = profile.LastUpdatedDate;
                        break;

                    case "Subscription":
                        pv.PropertyValue = profile.Subscription;
                        break;

                    case "Language":
                        pv.PropertyValue = profile.Language;
                        break;

                    case "FirstName":
                        pv.PropertyValue = profile.FirstName;
                        break;

                    case "MiddleName":
                        pv.PropertyValue = profile.MiddleName;
                        break;

                    case "LastName":
                        pv.PropertyValue = profile.LastName;
                        break;

                    case "Gender":
                        pv.PropertyValue = profile.Gender;
                        break;

                    case "BirthDate":
                        pv.PropertyValue = profile.BirthDate;
                        break;

                    case "Position":
                        pv.PropertyValue = profile.Position;
                        break;

                    case "Address":
                        pv.PropertyValue = profile.Address;
                        break;

                    case "UserId":
                        pv.PropertyValue = profile.UserId;
                        break;
                    default:
                        throw new ProviderException("Unsupported property.");
                }
                svc.Add(pv);
            }
            UpdateActivityDates(username, isAuthenticated, true);
            return svc;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection ppvc)
        {
            // The serializeAs attribute is ignored in this provider implementation.
            var username = (string)context["UserName"];
            var isAuthenticated = (bool)context["IsAuthenticated"];

            var profile = GetProfile(username, isAuthenticated) ?? CreateProfile(username, !isAuthenticated);

            foreach (SettingsPropertyValue pv in ppvc)
            {
                switch (pv.Property.Name)
                {
                    case "IsAnonymous":
                        profile.IsAnonymous = pv.PropertyValue != null && (bool)pv.PropertyValue;
                        break;

                    case "LastActivityDate":
                        profile.LastActivityDate = (DateTime)pv.PropertyValue;
                        break;

                    case "LastUpdatedDate":
                        profile.LastUpdatedDate = (DateTime)pv.PropertyValue;
                        break;

                    case "Subscription":
                        profile.Subscription = pv.PropertyValue.ToString();
                        break;

                    case "Language":
                        profile.Language = pv.PropertyValue.ToString();
                        break;

                    case "FirstName":
                        profile.FirstName = pv.PropertyValue.ToString();
                        break;

                    case "MiddleName":
                        profile.MiddleName = pv.PropertyValue.ToString();
                        break;

                    case "LastName":
                        profile.LastName = pv.PropertyValue.ToString();
                        break;

                    case "Gender":
                        profile.Gender = pv.PropertyValue.ToString();
                        break;

                    case "BirthDate":
                        profile.BirthDate = (DateTime)pv.PropertyValue;
                        break;

                    case "Position":
                        profile.Position = pv.PropertyValue.ToString();
                        break;

                    case "Address":
                        profile.Address = pv.PropertyValue.ToString();
                        break;

                    case "UserId":
                        profile.UserId = new Guid(pv.PropertyValue.ToString());
                        break;

                    default:
                        throw new ProviderException("Unsupported property.");
                }
            }
            _profileService.SaveOrUpdate(profile);
            UpdateActivityDates(username, isAuthenticated, false);
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            int deleteCount = 0;
            try
            {
                foreach (ProfileInfo p in profiles)
                {
                    if (DeleteProfile(p.UserName))
                        deleteCount++;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return deleteCount;
        }

        public override int DeleteProfiles(string[] usernames)
        {
            int deleteCount = 0;
            try
            {
                foreach (string user in usernames)
                {
                    if (DeleteProfile(user))
                        deleteCount++;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return deleteCount;
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption,
            DateTime userInactiveSinceDate)
        {
            string userIds = "";
            bool isAnonymous = false;
            switch (authenticationOption)
            {
                case ProfileAuthenticationOption.Anonymous:
                    isAnonymous = true;
                    break;

                case ProfileAuthenticationOption.Authenticated:
                    isAnonymous = false;
                    break;

                default:
                    break;
            }

            try
            {
                IList<Profiles> profs = null;
                // _profileService.GetProfilesByAppplicationNameLastActivityDate(ApplicationName, userInactiveSinceDate, isAnonymous);
                if (profs != null)
                {
                    foreach (Profiles p in profs)
                        userIds += p.Id.ToString() + ",";
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            if (userIds.Length > 0)
                userIds = userIds.Substring(0, userIds.Length - 1);

            return DeleteProfilesbyId(userIds.Split(','));
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption,
            string usernameToMatch,
            int pageIndex,
            int pageSize,
            out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, usernameToMatch, null, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(
            ProfileAuthenticationOption authenticationOption, string usernameToMatch,
            DateTime userInactiveSinceDate,
            int pageIndex,
            int pageSize,
            out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, usernameToMatch, userInactiveSinceDate, pageIndex, pageSize,
                out totalRecords);
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption,
            int pageIndex,
            int pageSize,
            out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, null, null, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption,
            DateTime userInactiveSinceDate,
            int pageIndex,
            int pageSize,
            out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, null, userInactiveSinceDate, pageIndex, pageSize,
                out totalRecords);
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption,
            DateTime userInactiveSinceDate)
        {
            int inactiveProfiles = 0;

            ProfileInfoCollection profiles =
                GetProfileInfo(authenticationOption, null, userInactiveSinceDate, 0, 0, out inactiveProfiles);

            return inactiveProfiles;
        }

        private ProfileInfoCollection GetProfileInfo(ProfileAuthenticationOption authenticationOption,
            string usernameToMatch,
            object userInactiveSinceDate,
            int pageIndex,
            int pageSize,
            out int totalRecords)
        {
            bool isAnonymous = false;
            var profilesInfoColl = new ProfileInfoCollection();
            switch (authenticationOption)
            {
                case ProfileAuthenticationOption.Anonymous:
                    isAnonymous = true;
                    break;

                case ProfileAuthenticationOption.Authenticated:
                    isAnonymous = false;
                    break;

                default:
                    break;
            }

            try
            {
                IList<Profiles> profiles = null;
                //_profileService.GetProfilesByAppplicationNameLastActivityDate(ApplicationName, (DateTime)userInactiveSinceDate, isAnonymous);
                IList<Profiles> profiles2 = null;

                if (profiles == null)
                    totalRecords = 0;
                else if (profiles.Count < 1)
                    totalRecords = 0;
                else
                    totalRecords = profiles.Count;

                //IF USER NAME TO MATCH then fileter out those
                //Membership.FMembershipProvider us = new INCT.FNHProviders.Membership.FMembershipProvider();
                //us.g
                MembershipUserCollection uc = Membership.FindUsersByName(usernameToMatch);

                if (usernameToMatch != null)
                {
                    if (totalRecords > 0)
                    {
                        foreach (Profiles p in profiles)
                        {
                            if (IsUserInCollection(uc, usernameToMatch))
                                profiles2.Add(p);
                        }

                        if (profiles2 == null)
                            profiles2 = profiles;
                        else if (profiles2.Count < 1)
                            profiles2 = profiles;
                        else
                            totalRecords = profiles2.Count;
                    }
                    else
                        profiles2 = profiles;
                }
                else
                    profiles2 = profiles;

                if (totalRecords <= 0)
                    return profilesInfoColl;

                if (pageSize == 0)
                    return profilesInfoColl;

                int counter = 0;
                int startIndex = pageSize * (pageIndex - 1);
                int endIndex = startIndex + pageSize - 1;

                foreach (Profiles p in profiles2)
                {
                    if (counter >= endIndex)
                        break;
                    if (counter >= startIndex)
                    {
                        ProfileInfo pi = GetProfileInfoFromProfile(p);
                        profilesInfoColl.Add(pi);
                    }
                    counter++;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return profilesInfoColl;
        }

        #endregion Public Methods
    }
}