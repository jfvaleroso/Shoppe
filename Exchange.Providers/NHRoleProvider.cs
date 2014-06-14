using Castle.Windsor;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data.Odbc;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Security;
using Roles = Exchange.Core.Entities.Roles;

namespace Exchange.Providers
{
    public sealed class NhRoleProvider : RoleProvider
    {
        private readonly WindsorContainer _container = (WindsorContainer)HttpContext.Current.Application["Windsor"];
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public NhRoleProvider()
        {
            _userService = _container.Resolve<IUserService>();
            _roleService = _container.Resolve<IRoleService>();
        }
        
        #region private

        private string _applicationName;
        private string _connectionString;
        private string eventLog = "Application";
        private string eventSource = "RoleProvider";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";

        #endregion private

        #region Properties

        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }
        public bool WriteExceptionsToEventLog { get; set; }

        #endregion Properties

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

        #endregion Helper Functions

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
            base.Initialize(name, config);

            _applicationName = GetConfigValue(config["applicationName"], HostingEnvironment.ApplicationVirtualPath);
            WriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));

            // Initialize Connection.
            ConnectionStringSettings ConnectionStringSettings =
                ConfigurationManager.ConnectionStrings[config["connectionStringName"]];
            if (ConnectionStringSettings == null || ConnectionStringSettings.ConnectionString.Trim() == "")
                throw new ProviderException("Connection string cannot be blank.");

            _connectionString = ConnectionStringSettings.ConnectionString;
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
                        usr = _userService.GetUserByUsernameApplicationName(username, ApplicationName);

                        if (usr != null)
                        {
                            //get the role first from db
                            Roles role = _roleService.GetDataByName(rolename, ApplicationName);
                            //Roles role = GetRole(rolename);
                            usr.AddRole(role);
                        }
                    }
                    _userService.SaveOrUpdate(usr);
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
                var role = new Roles();
                role.ApplicationName = ApplicationName;
                role.RoleName = rolename;
                _roleService.Save(role);
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
                Roles role = _roleService.GetDataByName(rolename, ApplicationName);
                _roleService.Delete(role.Id);
            }
            catch (OdbcException e)
            {
                throw e;
            }

            return deleted;
        }

        public override string[] GetAllRoles()
        {
            var sb = new StringBuilder();

            try
            {
                IList<Roles> allroles = _roleService.GetDataByApplicationName(ApplicationName);

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
            var sb = new StringBuilder();

            try
            {
                usr = _userService.GetUserByUsernameApplicationName(username, ApplicationName);
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
            var sb = new StringBuilder();

            try
            {
                Roles role = _roleService.GetDataByName(rolename, ApplicationName);
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
            var sb = new StringBuilder();

            try
            {
                usr = _userService.GetUserByUsernameApplicationName(username, ApplicationName);

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
                    usr = _userService.GetUserByUsernameApplicationName(username, ApplicationName);

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

                    _userService.SaveOrUpdate(usr);
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

            var sb = new StringBuilder();

            try
            {
                Roles role = _roleService.GetDataByName(rolename, ApplicationName);
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
            var sb = new StringBuilder();

            try
            {
                Roles role = _roleService.GetDataByName(rolename, ApplicationName);

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

        #endregion Public Methods
    }
}