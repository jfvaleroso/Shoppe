using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Data.Odbc;
using System.Configuration.Provider;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.Configuration;
using Exchange.Core.Entities;
using Exchange.Core.Repositories;
using Exchange.Core.UnitOfWork;
using Exchange.Core.Services.IServices;
using System.Web.Mvc;
using Exchange.Core.Services.Services;





namespace Exchange.Providers
{
    public sealed class NHProfileProvider : System.Web.Profile.ProfileProvider
    {
       
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        public NHProfileProvider()
            : this(DependencyResolver.Current.GetService<IUserService>(), DependencyResolver.Current.GetService<IProfileService>())
        {
        }
        public NHProfileProvider(IUserService userService,IProfileService profileService)
        {
            this.userService = userService;
            this.profileService = profileService;
            Initialize();
            
        }


        #region private
        private string connectionString;
        private string _applicationName;
       
         private bool HasInitialized { get; set; }
        #endregion
        #region Properties
        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }
        #endregion
        #region Helper Functions
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }
        #endregion

        #region Private Methods
        private Profiles GetProfile(string username, bool isAuthenticated)
        {
            Profiles profile = null;
            bool isAnonymous = !isAuthenticated;      
                try
                {
                    Users usr = this.userService.GetUserByUsernameApplicationName(username, this.ApplicationName);
                   
                    if (usr != null)
                    {
                        profile = this.profileService.GetProfileByUserId(usr.Id, isAnonymous);
                       
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
                    Users usr = this.userService.GetUserByUsernameApplicationName(username, this.ApplicationName);

                    if (usr != null)
                    {
                        profile = this.profileService.GetProfileByUserId(usr.Id);
                    }
                }
                catch (Exception e)
                {
                  
                        throw e;
                }

            
            return profile;
        }
        private Profiles GetProfile(int Id)
        {
            Profiles profile = null;    
                try
                {
                    Users usr = this.userService.GetUserByIdApplicationName(Id, this.ApplicationName);
                  
                    if (usr != null)
                    {
                        profile = this.profileService.GetProfileByUserId(usr.Id);
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
            Profiles p = new Profiles();
            bool profileCreated = false;      
                    try
                    {
                        Users usr = this.userService.GetUserByUsernameApplicationName(username, this.ApplicationName);
                       
                        if (usr != null) //membership user exits so create a profile
                        {
                            p.Users_Id = usr.Id;
                            p.IsAnonymous = isAnonymous;
                            p.LastUpdatedDate = System.DateTime.Now;
                            p.LastActivityDate = System.DateTime.Now;
                            p.ApplicationName = this.ApplicationName;
                            p.BirthDate = System.DateTime.Now;
                            this.profileService.Save(p);
                            
                            profileCreated = true;
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
            else
                return null;

        }

        private bool IsMembershipUser(string username)
        {
            bool hasMembership = false;
                try
                {
                    Users usr = this.userService.GetUserByUsernameApplicationName(username, this.ApplicationName);
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

                       this.profileService.SaveChanges(pr);
                        
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
                      this.profileService.Delete(profile);
                        
                    }
                    catch (Exception e)
                    {
                        
                            throw e;
                    }
                
            

            return true;
        }
        private bool DeleteProfile(int id)
        {
            // Check for valid user name.
            Profiles profile = GetProfile(id);
            if (profile == null)
                return false;

          
               
                    try
                    {
                        this.profileService.Delete(profile);
                        
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
            usr = this.userService.GetUserByIdApplicationName(p.Users_Id, this.ApplicationName);
            if (usr == null)
                throw new ProviderException("The userid not found in memebership tables.GetProfileInfoFromProfile(p)");

            // ProfileInfo.Size not currently implemented.
            ProfileInfo pi = new ProfileInfo(usr.Username,
                p.IsAnonymous, p.LastActivityDate, p.LastUpdatedDate, 0);

            return pi;
        }
        #endregion

        #region Public Methods
        private void Initialize()
        {
            if (!HasInitialized)
            {
                string configPath = "~/web.config";
                Configuration config = WebConfigurationManager.OpenWebConfiguration(configPath);
                ProfileSection section = (ProfileSection)config.GetSection("system.web/profile");
                ProviderSettingsCollection settings = section.Providers;
                NameValueCollection profileParams = settings[section.DefaultProvider].Parameters;
                Initialize(section.DefaultProvider, profileParams);
                HasInitialized = true;
            }


        }
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
            if (!HasInitialized)
            {
                base.Initialize(name, config);
            }

            _applicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
           
            // Initialize Connection.
            ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];
            if (ConnectionStringSettings == null || ConnectionStringSettings.ConnectionString.Trim() == "")
                throw new ProviderException("Connection string cannot be blank.");

            connectionString = ConnectionStringSettings.ConnectionString;
        }
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection ppc)
        {
            string username = (string)context["UserName"];
            bool isAuthenticated = (bool)context["IsAuthenticated"];
            Profiles profile = null;

          
            profile = GetProfile(username, isAuthenticated);
            // The serializeAs attribute is ignored in this provider implementation.
            SettingsPropertyValueCollection svc = new SettingsPropertyValueCollection();

            if (profile == null)
            {
                if (IsMembershipUser(username))
                    profile = CreateProfile(username, false);
                else
                    
                    throw new ProviderException("Profile cannot be created. There is no membership user");
            }


            foreach (SettingsProperty prop in ppc)
            {
                SettingsPropertyValue pv = new SettingsPropertyValue(prop);
                switch (prop.Name)
                {
                       case "IsAnonymous":
                                profile.IsAnonymous = (bool)pv.PropertyValue;
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
            Profiles profile =new Profiles();
            // The serializeAs attribute is ignored in this provider implementation.
            string username = (string)context["UserName"];
            bool isAuthenticated = (bool)context["IsAuthenticated"];

        
                    profile = GetProfile(username, isAuthenticated);

                    if (profile == null)
                        profile = CreateProfile(username, !isAuthenticated);

                    foreach (SettingsPropertyValue pv in ppvc)
                    {
                        switch (pv.Property.Name)
                        {
                            case "IsAnonymous":
                                profile.IsAnonymous = (bool)pv.PropertyValue;
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
                         
                            default:
                                throw new ProviderException("Unsupported property.");
                        }    
                }
            
              this.profileService.SaveChanges(profile);

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
        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
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
                    IList<Profiles> profs = this.profileService.GetProfilesByAppplicationNameLastActivityDate(this.ApplicationName, userInactiveSinceDate, isAnonymous);
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
        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch,
                                                                       int pageIndex,
                                                                       int pageSize,
                                                                       out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, usernameToMatch, null, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch,
                                                                              DateTime userInactiveSinceDate,
                                                                              int pageIndex,
                                                                              int pageSize,
                                                                              out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, usernameToMatch, userInactiveSinceDate, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex,
                                                                              int pageSize,
                                                                              out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, null, null, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate,
                                                                          int pageIndex,
                                                                          int pageSize,
                                                                          out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, null, userInactiveSinceDate, pageIndex, pageSize, out totalRecords);
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            int inactiveProfiles = 0;

            ProfileInfoCollection profiles =
              GetProfileInfo(authenticationOption, null, userInactiveSinceDate, 0, 0, out inactiveProfiles);

            return inactiveProfiles;
        }

       
        
        private ProfileInfoCollection GetProfileInfo(ProfileAuthenticationOption authenticationOption, string usernameToMatch,
                                                                      object userInactiveSinceDate,
                                                                      int pageIndex,
                                                                      int pageSize,
                                                                      out int totalRecords)
        {

            bool isAnonymous = false;
            ProfileInfoCollection profilesInfoColl = new ProfileInfoCollection();
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
                   
                    IList<Profiles> profiles = this.profileService.GetProfilesByAppplicationNameLastActivityDate(this.ApplicationName, (DateTime)userInactiveSinceDate, isAnonymous);
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
                    System.Web.Security.MembershipUserCollection uc = System.Web.Security.Membership.FindUsersByName(usernameToMatch);

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



        #endregion



        
    }
}