
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.Configuration;
using NHibernate;
using Exchange.Core.Entities;
using Exchange.Provider.Helper;
using System.Web.Security;


namespace Exchange.Provider.Profile
{
    public sealed class NHProfileProvider : System.Web.Profile.ProfileProvider 
    {
        #region private
        private string eventSource = "FNHProfileProvider";
        private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";
        private string connectionString;
        private string _applicationName;
        private static ISessionFactory _sessionFactory;

        #endregion

        #region Properties
        /// <summary>Gets the session factory.</summary>
        private static ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }
        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        public bool WriteExceptionsToEventLog { get; set; }
        #endregion

        #region Helper Functions
        // A helper function to retrieve config values from the configuration file
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }

        private void WriteToEventLog(Exception e, string action)
        {
            
        }
        #endregion

        #region Private Methods
        //get a role by name
        private Profiles  GetProfile(string username,bool isAuthenticated)
        {
            Profiles  profile = null;
            //Is authenticated and IsAnonmous are opposites,so flip sign,IsAuthenticated = true -> notAnonymous
            bool isAnonymous = !isAuthenticated; 
            
            using (ISession session = SessionFactory.OpenSession())
            {
                try
                {
                    Users usr = session.CreateCriteria(typeof(Users))
                                                .Add(NHibernate.Criterion.Restrictions.Eq("Username", username))
                                                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", ApplicationName))
                                                .UniqueResult<Users>();

                    if (usr != null)
                    {

                       profile= session.CreateCriteria(typeof(Profiles))
                                        .Add(NHibernate.Criterion.Restrictions.Eq("UserId", usr.Id))
                                        .Add(NHibernate.Criterion.Restrictions.Eq("IsAnonymous", isAnonymous))
                                        .UniqueResult<Profiles>();
                    }
                }
                catch (Exception e)
                {
                    if (WriteExceptionsToEventLog)
                        WriteToEventLog(e, "GetProfileWithIsAuthenticated");
                    else
                        throw e;
                }

            }
            return profile;
        }

        private Profiles GetProfile(string username)
        {
            Profiles profile = null;
            using (ISession session = SessionFactory.OpenSession())
            {
                try
                {
                    Users usr = session.CreateCriteria(typeof(Users))
                                                .Add(NHibernate.Criterion.Restrictions.Eq("Username", username))
                                                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", ApplicationName))
                                                .UniqueResult<Users>();

                    if (usr != null)
                    {
                        profile = session.CreateCriteria(typeof(Profiles))
                                            .Add(NHibernate.Criterion.Restrictions.Eq("UserId", usr.Id))
                                            .UniqueResult<Profiles>();
                    }                    
                }
                catch (Exception e)
                {
                    if (WriteExceptionsToEventLog)
                        WriteToEventLog(e, "GetProfile(username)");
                    else
                        throw e;
                }

            }
            return profile;
        }

        private Profiles GetProfile(int Id)
        {
            Profiles profile = null;
            using (ISession session = SessionFactory.OpenSession())
            {
                try
                {
                    Users usr = session.CreateCriteria(typeof(Users))
                                                .Add(NHibernate.Criterion.Restrictions.Eq("Id", Id))
                                                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", ApplicationName))
                                                .UniqueResult<Users>();

                    if (usr != null)
                    {
                        profile = session.CreateCriteria(typeof(Profiles))
                                            .Add(NHibernate.Criterion.Restrictions.Eq("UserId", usr.Id))
                                            .UniqueResult<Profiles>();
                    }
                    else
                        throw new ProviderException("Membership User does not exist");

                }
                catch (Exception e)
                {
                    if (WriteExceptionsToEventLog)
                        WriteToEventLog(e, "GetProfile(id)");
                    else
                        throw e;
                }

            }
            return profile;
        }

        private Profiles CreateProfile(string username, bool isAnonymous)
        {
            Profiles p = new Profiles();
            bool profileCreated = false;

            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        Users usr = session.CreateCriteria(typeof(Users))
                                                    .Add(NHibernate.Criterion.Restrictions.Eq("Username", username))
                                                    .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", ApplicationName))
                                                    .UniqueResult<Users>();

                        if (usr != null) //membership user exits so create a profile
                        {
                            p.Users_Id= usr.Id;
                            p.IsAnonymous = isAnonymous;
                            p.LastUpdatedDate = System.DateTime.Now;
                            p.LastActivityDate = System.DateTime.Now; 
                            p.ApplicationName = ApplicationName;
                            p.BirthDate = DateTime.Now;
                            session.Save(p);
                            transaction.Commit();
                            profileCreated = true;
                        }
                        else
                            throw new ProviderException("Membership User does not exist.Profile cannot be created.");

                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                            WriteToEventLog(e, "GetProfile");
                        else
                            throw e;
                    }
                }

            }

            if (profileCreated) 
                return p;
            else
                return null;
            
        }

        private bool IsMembershipUser(string username)
        {
           
            bool hasMembership = false;

            using (ISession session = SessionFactory.OpenSession())
            {

                try
                {
                    Users usr = session.CreateCriteria(typeof(Users))
                                                .Add(NHibernate.Criterion.Restrictions.Eq("Username", username))
                                                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", ApplicationName))
                                                .UniqueResult<Users>();

                    if (usr != null) //membership user exits so create a profile
                        hasMembership = true;
                }
                catch (Exception e)
                {
                    if (WriteExceptionsToEventLog)
                        WriteToEventLog(e, "GetProfile");
                    else
                        throw e;
                }

            }

            return hasMembership;

        }

        private bool IsUserInCollection(MembershipUserCollection uc,string username)
        {
            bool isInColl = false;
            foreach (MembershipUser u in uc)
            {
                if(u.UserName.Equals(username))
                    isInColl = true;
            }

            return isInColl;

        }

        // Updates the LastActivityDate and LastUpdatedDate values  when profile properties are accessed by the
        // GetPropertyValues and SetPropertyValues methods. Passing true as the activityOnly parameter will update only the LastActivityDate.

        private void UpdateActivityDates(string username, bool isAuthenticated, bool activityOnly)
        {
            //Is authenticated and IsAnonmous are opposites,so flip sign,IsAuthenticated = true -> notAnonymous
            bool isAnonymous = !isAuthenticated;
            DateTime activityDate = DateTime.Now;

            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Profiles pr = GetProfile(username, isAuthenticated);
                    if(pr == null)
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

                        session.Update(pr);
                        transaction.Commit();  
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                        {
                            WriteToEventLog(e, "UpdateActivityDates");
                            throw new ProviderException(exceptionMessage);
                        }
                        else
                           throw e;
                    }
                }
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

            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(profile);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                        {
                            WriteToEventLog(e, "DeleteProfile");
                            throw new ProviderException(exceptionMessage);
                        }
                        else
                            throw e;
                    }
                }
            }

            return true;
        }

        private bool DeleteProfile(int id)
        {
            // Check for valid user name.
            Profiles profile = GetProfile(id);
            if (profile == null)
                return false;

            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(profile);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                        {
                            WriteToEventLog(e, "DeleteProfile(id)");
                            throw new ProviderException(exceptionMessage);
                        }
                        else
                            throw e;
                    }
                }
            }

            return true;
        }

        private  int DeleteProfilesbyId(string[] ids)
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
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "DeleteProfiles(Id())");
                    throw new ProviderException(exceptionMessage);
                }
                else
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
            using (ISession session = SessionFactory.OpenSession())
            {
                usr = session.CreateCriteria(typeof(Users))
                                        .Add(NHibernate.Criterion.Restrictions.Eq("Id", p.Users_Id))
                                        .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", ApplicationName))
                                        .UniqueResult<Users>();
            }
            if (usr == null)
                throw new ProviderException("The userid not found in memebership tables.GetProfileInfoFromProfile(p)");

            // ProfileInfo.Size not currently implemented.
            ProfileInfo pi = new ProfileInfo(usr.Username,
                p.IsAnonymous, p.LastActivityDate, p.LastUpdatedDate, 0);

            return pi;
        }
        #endregion

        #region Public Methods
        public override void Initialize(string name, NameValueCollection config)
        {
            // Initialize values from web.config.

            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "FNHProfileProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sample Fluent Nhibernate Profile provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            _applicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            WriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));

            // Initialize Connection.
            ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];
            if (ConnectionStringSettings == null || ConnectionStringSettings.ConnectionString.Trim() == "")
                throw new ProviderException("Connection string cannot be blank.");

            connectionString = ConnectionStringSettings.ConnectionString;
            // create our Fluent NHibernate session factory
            _sessionFactory = SessionHelper.CreateSessionFactory(connectionString);
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context,SettingsPropertyCollection ppc)
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
                    profile = CreateProfile(username,false);
                else
                    throw new ProviderException("Profile cannot be created. There is no membership user");
            }
               
            
            foreach (SettingsProperty prop in ppc) 
            {
                SettingsPropertyValue pv = new SettingsPropertyValue(prop);
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
                    case "Address":
                        pv.PropertyValue = profile.Address;
                        break;
                    case "Position":
                        pv.PropertyValue = profile.Position;
                        break;
                    case "UserId":
                        pv.PropertyValue = profile.Users_Id;
                        break;

                    default:
                        throw new ProviderException("Unsupported property." + pv.ToString());
                }

                    svc.Add(pv);
                }
           
            UpdateActivityDates(username, isAuthenticated, true);
            return svc;
        }

        public override void SetPropertyValues(SettingsContext context,SettingsPropertyValueCollection ppvc)
        {
            Profiles profile = null;
            // The serializeAs attribute is ignored in this provider implementation.
            string username = (string)context["UserName"];
            bool isAuthenticated = (bool)context["IsAuthenticated"];

            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

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
                                pv.PropertyValue = profile.Users_Id;
                                break;
                            default:
                                throw new ProviderException("Unsupported property.");
                        }
                    }

                    session.SaveOrUpdate(profile);
                    transaction.Commit();  
                }
            }

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
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "DeleteProfiles(ProfileInfoCollection)");
                    throw new ProviderException(exceptionMessage);
                }
                else
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
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "DeleteProfiles(String())");
                    throw new ProviderException(exceptionMessage);
                }
                else
                    throw e;

            }
            return deleteCount;
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption,DateTime userInactiveSinceDate)
        {
            string userIds = "";
            bool anaon = false ;
            switch (authenticationOption)
            {
                case ProfileAuthenticationOption.Anonymous:
                    anaon= true;
                    break;
                case ProfileAuthenticationOption.Authenticated:
                    anaon= false;
                    break;
                default:
                    break;
            }

            using (ISession session = SessionFactory.OpenSession())
            {
                try
                {
                    IList<Profiles> profs = session.CreateCriteria(typeof(Profiles))
                                                    .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", ApplicationName))
                                                    .Add(NHibernate.Criterion.Restrictions.Le("LastActivityDate", userInactiveSinceDate))
                                                    .Add(NHibernate.Criterion.Restrictions.Eq("IsAnonymous", anaon))
                                                    .List<Profiles>();

                    if (profs != null)
                    {
                        foreach (Profiles p in profs)
                            userIds += p.Id.ToString() + ",";
                       
                    }
                }
                catch (Exception e)
                {
                    if (WriteExceptionsToEventLog)
                        WriteToEventLog(e, "DeleteInactiveProfiles");
                    else
                        throw e;
                }

            }

            if (userIds.Length > 0)
                userIds = userIds.Substring(0, userIds.Length - 1);


            return DeleteProfilesbyId(userIds.Split(','));
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption,string usernameToMatch,
                                                                       int pageIndex,
                                                                       int pageSize,
                                                                       out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, usernameToMatch,null, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption,string usernameToMatch,
                                                                              DateTime userInactiveSinceDate,
                                                                              int pageIndex,
                                                                              int pageSize,
                                                                              out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, usernameToMatch, userInactiveSinceDate,pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption,int pageIndex,
                                                                              int pageSize,
                                                                              out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, null, null,pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption,DateTime userInactiveSinceDate,
                                                                          int pageIndex,
                                                                          int pageSize,
                                                                          out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, null, userInactiveSinceDate,pageIndex, pageSize, out totalRecords);
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption,DateTime userInactiveSinceDate)
        {
            int inactiveProfiles = 0;

            ProfileInfoCollection profiles =
              GetProfileInfo(authenticationOption, null, userInactiveSinceDate, 0, 0, out inactiveProfiles);

            return inactiveProfiles;
        }


        // GetProfileInfo
        // Retrieves a count of profiles and creates a 
        // ProfileInfoCollection from the profile data in the 
        // database. Called by GetAllProfiles, GetAllInactiveProfiles,
        // FindProfilesByUserName, FindInactiveProfilesByUserName, 
        // and GetNumberOfInactiveProfiles.
        // Specifying a pageIndex of 0 retrieves a count of the results only.
        //

        private ProfileInfoCollection GetProfileInfo(ProfileAuthenticationOption authenticationOption,string usernameToMatch,
                                                                      object userInactiveSinceDate,
                                                                      int pageIndex,
                                                                      int pageSize,
                                                                      out int totalRecords)
        {
            
            bool isAnaon = false;
            ProfileInfoCollection profilesInfoColl = new ProfileInfoCollection();
            switch (authenticationOption)
            {
                case ProfileAuthenticationOption.Anonymous:
                    isAnaon = true;
                    break;
                case ProfileAuthenticationOption.Authenticated:
                    isAnaon = false;
                    break;
                default:
                    break;
            }

            using (ISession session = SessionFactory.OpenSession())
            {
                try
                {
                    ICriteria cprofiles = session.CreateCriteria(typeof(Profiles));
                    cprofiles.Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", ApplicationName));



                    if (userInactiveSinceDate != null)
                        cprofiles.Add(NHibernate.Criterion.Restrictions.Le("LastActivityDate", (DateTime)userInactiveSinceDate));

                    cprofiles.Add(NHibernate.Criterion.Restrictions.Eq("IsAnonymous", isAnaon));


                    IList<Profiles> profiles = cprofiles.List<Profiles>();
                     IList<Profiles> profiles2 = null;

                    if (profiles == null)
                        totalRecords = 0;
                    else if (profiles.Count < 1)
                        totalRecords = 0;
                    else
                        totalRecords = profiles.Count; 



                    //IF USER NAME TO MATCH then fileter out those
                    //Membership.FNHMembershipProvider us = new INCT.FNHProviders.Membership.FNHMembershipProvider();
                    //us.g
                    System.Web.Security.MembershipUserCollection uc = System.Web.Security.Membership.FindUsersByName(usernameToMatch);

                    if (usernameToMatch != null)
                    {
                        if(totalRecords >0)
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
                    if (WriteExceptionsToEventLog)
                    {
                        WriteToEventLog(e, "GetProfileInfo");
                        throw new ProviderException(exceptionMessage);
                    }
                    else
                        throw e;

                }
            }
            return profilesInfoColl;
        }



        #endregion
    }
}
