using System;
using System.Collections.Generic;
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
using System.Web.Configuration;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using System.Web.Mvc;



namespace Exchange.Providers
{
    public sealed class NHRoleProvider : System.Web.Security.RoleProvider
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        public NHRoleProvider()
            : this(DependencyResolver.Current.GetService<IUserService>(), DependencyResolver.Current.GetService<IRoleService>())
        {
        }

        public NHRoleProvider(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService= roleService;
            Initialize();
        }

         private void Initialize()
        {
            if (!HasInitialized)
            {
                string configPath = "~/web.config";
               Configuration config = WebConfigurationManager.OpenWebConfiguration(configPath);
               RoleManagerSection section = (RoleManagerSection)config.GetSection("system.web/roleManager");
               ProviderSettingsCollection settings = section.Providers;
               NameValueCollection roleManagerParams = settings[section.DefaultProvider].Parameters;
               Initialize(section.DefaultProvider, roleManagerParams);
               HasInitialized = true;
            }


        }
      

        #region private
        private string eventSource = "RoleProvider";
        private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";
        private string connectionString;
        private string _applicationName;
      
        #endregion
        #region Properties
        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }
         private bool HasInitialized { get; set; }
        public bool WriteExceptionsToEventLog { get; set; }
        #endregion
        #region Helper Functions
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
        #region Public Methods
        public override void Initialize(string name, NameValueCollection config)
        {
            // Initialize values from web.config.

            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "RoleProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sample Fluent Nhibernate Roles provider");
            }

            // Initialize the abstract base class.

            if (!HasInitialized)
            {
                base.Initialize(name, config);
            }

            _applicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            WriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));

            // Initialize Connection.
            ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];
            if (ConnectionStringSettings == null || ConnectionStringSettings.ConnectionString.Trim() == "")
                throw new ProviderException("Connection string cannot be blank.");

            connectionString = ConnectionStringSettings.ConnectionString;
        
        }
        public override void AddUsersToRoles(string[] usernames, string[] rolenames)
        {
            Users usr = null;
            foreach (string rolename in rolenames)
            {
                if (!RoleExists(rolename))
                    throw new ProviderException(String.Format("Roles name {0} not found.", rolename));
            }

            foreach (string username in usernames)
            {
                if (username.Contains(","))
                    throw new ArgumentException(String.Format("User names {0} cannot contain commas.", username));
                //is user not exiting //throw exception

                foreach (string rolename in rolenames)
                {
                    if (IsUserInRole(username, rolename))
                        throw new ProviderException(String.Format("User {0} is already in role {1}.", username, rolename));
                }
            }

         
              
                    try
                    {
                        foreach (string username in usernames)
                        {
                            foreach (string rolename in rolenames)
                            {
                                //get the user
                                usr = this.userService.GetUserByUsernameApplicationName(username, this.ApplicationName);
                               
                                if (usr != null)
                                {
                                    //get the role first from db
                                    Roles role = this.roleService.GetRoleByRoleNameApplicationName(rolename, this.ApplicationName);                                  
                                    //Roles role = GetRole(rolename);
                                    usr.AddRole(role);
                                }
                            }
                            this.userService.SaveOrUpdate(usr);
                        }
                       
                    }
                    catch (Exception e)
                    {
                        
                            throw e;
                    }

               
            
        }
        public override void CreateRole(string rolename)
        {
            if (rolename.Contains(","))
                throw new ArgumentException("Roles names cannot contain commas.");

            if (RoleExists(rolename))
                throw new ProviderException("Roles name already exists.");

         
               
                    try
                    {
                        Roles role = new Roles();
                        role.ApplicationName = this.ApplicationName;
                        role.RoleName = rolename;
                        this.roleService.Save(role);
                       
                    }
                    catch (OdbcException e)
                    {
                        
                            throw e;
                    }
                
            
        }
        public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
        {
            bool deleted = false;
            if (!RoleExists(rolename))
                throw new ProviderException("Roles does not exist.");

            if (throwOnPopulatedRole && GetUsersInRole(rolename).Length > 0)
                throw new ProviderException("Cannot delete a populated role.");


                    try
                    {
                      Roles role = this.roleService.GetRoleByRoleNameApplicationName(rolename,this.ApplicationName);
                      this.roleService.Delete(role);
                      

                    }
                    catch (OdbcException e)
                    {
                       
                            throw e;
                    }
              

            return deleted;
        }
        public override string[] GetAllRoles()
        {
            StringBuilder sb = new StringBuilder();
           
              
                    try
                    {
                        IList<Roles> allroles =this.roleService.GetRolesByApplicationName(this.ApplicationName);

                        foreach (Roles r in allroles)
                        {
                            sb.Append(r.RoleName + ",");
                        }
                    }
                    catch (Exception e)
                    {
                        
                            throw e;
                    }
                
            

            if (sb.Length > 0)
            {
                // Remove trailing comma.
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString().Split(',');
            }

            return new string[0];
        }
        public override string[] GetRolesForUser(string username)
        {
            Users usr = null;
            IList<Roles> usrroles = null;
            StringBuilder sb = new StringBuilder();
          
               
                    try
                    {
                        usr =this.userService.GetUserByUsernameApplicationName(username, this.ApplicationName); 
                        if (usr != null)
                        {
                            usrroles = usr.Roles;
                            foreach (Roles r in usrroles)
                            {
                                sb.Append(r.RoleName + ",");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                       
                            throw e;
                    }
                
            

            if (sb.Length > 0)
            {
                // Remove trailing comma.
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString().Split(',');
            }

            return new string[0];
        }
        public override string[] GetUsersInRole(string rolename)
        {
            StringBuilder sb = new StringBuilder();
           
               
                    try
                    {
                        Roles role =this.roleService.GetRoleByRoleNameApplicationName(rolename, this.ApplicationName);
                        IList<Users> usrs = role.UsersInRole;

                        foreach (Users u in usrs)
                        {
                            sb.Append(u.Username + ",");
                        }
                    }
                    catch (Exception e)
                    {
                      
                            throw e;
                    }
               
            

            if (sb.Length > 0)
            {
                // Remove trailing comma.
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString().Split(',');
            }

            return new string[0];
        }
        public override bool IsUserInRole(string username, string rolename)
        {
            bool userIsInRole = false;
            Users usr = null;
            IList<Roles> usrroles = null;
            StringBuilder sb = new StringBuilder();
           
               
                    try
                    {
                        usr = this.userService.GetUserByUsernameApplicationName(username, this.ApplicationName);

                        if (usr != null)
                        {
                            usrroles = usr.Roles;
                            if (usrroles != null)
                            {
                                foreach (Roles r in usrroles)
                                {
                                    if (r.RoleName.Equals(rolename))
                                    {
                                        userIsInRole = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                       
                            throw e;
                    }
                
            
            return userIsInRole;
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames)
        {
            Users usr = null;
            foreach (string rolename in rolenames)
            {
                if (!RoleExists(rolename))
                    throw new ProviderException(String.Format("Roles name {0} not found.", rolename));
            }

            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    if (!IsUserInRole(username, rolename))
                        throw new ProviderException(String.Format("User {0} is not in role {1}.", username, rolename));
                }
            }

            //get user , get his roles , the remove the role and save   
           
               
                    try
                    {
                        foreach (string username in usernames)
                        {
                            usr = this.userService.GetUserByUsernameApplicationName(username, this.ApplicationName);

                            var rolestodelete = new List<Roles>();
                            foreach (string rolename in rolenames)
                            {
                                IList<Roles> roles = usr.Roles;
                                foreach (Roles r in roles)
                                {
                                    if (r.RoleName.Equals(rolename))
                                        rolestodelete.Add(r);

                                }
                            }
                            foreach (Roles rd in rolestodelete)
                                usr.RemoveRole(rd);


                           this.userService.SaveOrUpdate(usr);
                        }
                        
                    }
                    catch (OdbcException e)
                    {
                       
                            throw e;
                    }
                
            

        }
        public override bool RoleExists(string rolename)
        {
            bool exists = false;

            StringBuilder sb = new StringBuilder();
         
               
                    try
                    {
                        Roles role = this.roleService.GetRoleByRoleNameApplicationName(rolename, this.ApplicationName);
                        if (role != null)
                            exists = true;

                    }
                    catch (Exception e)
                    {
                        
                            throw e;
                    }
               
            
            return exists;
        }
        public override string[] FindUsersInRole(string rolename, string usernameToMatch)
        {
            StringBuilder sb = new StringBuilder();
         
              
                    try
                    {
                        Roles role = this.roleService.GetRoleByRoleNameApplicationName(rolename, this.ApplicationName);

                        IList<Users> users = role.UsersInRole;
                        if (users != null)
                        {
                            foreach (Users u in users)
                            {
                                if (String.Compare(u.Username, usernameToMatch, true) == 0)
                                    sb.Append(u.Username + ",");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                      
                            throw e;
                    }
                
                if (sb.Length > 0)
                {
                    // Remove trailing comma.
                    sb.Remove(sb.Length - 1, 1);
                    return sb.ToString().Split(',');
                }
                return new string[0];
            
        }
        #endregion
    }
}