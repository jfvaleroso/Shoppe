using Castle.Windsor;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data.Odbc;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Security;

namespace Exchange.Providers
{
    public class NhMembershipProvider : MembershipProvider
    {
        #region Constructor

        private readonly WindsorContainer _container = (WindsorContainer)HttpContext.Current.Application["Windsor"];
        private readonly IUserService _userService;

        public NhMembershipProvider()
        {
            _userService = _container.Resolve<IUserService>();
        }

        #endregion Constructor

        #region Private

        // Global connection string, generated password length, generic exception message, event log info.
        private string _applicationName = "Exchange";

        private bool _enablePasswordReset;
        private bool _enablePasswordRetrieval;

        // Used when determining encryption key values.
        private MachineKeySection _machineKey;

        private int _maxInvalidPasswordAttempts;
        private int _minRequiredNonAlphanumericCharacters;
        private int _minRequiredPasswordLength;
        private int _passwordAttemptWindow;
        private MembershipPasswordFormat _passwordFormat = MembershipPasswordFormat.Encrypted;
        private string _passwordStrengthRegularExpression;
        private bool _requiresQuestionAndAnswer;
        private bool _requiresUniqueEmail;
        private string _connectionString;
        private const int NewPasswordLength = 8;

        #endregion Private

        #region Public Propeties

        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        public override bool EnablePasswordReset
        {
            get { return _enablePasswordReset; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return _enablePasswordRetrieval; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return _requiresQuestionAndAnswer; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return _requiresUniqueEmail; }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return _maxInvalidPasswordAttempts; }
        }

        public override int PasswordAttemptWindow
        {
            get { return _passwordAttemptWindow; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return _passwordFormat; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return _minRequiredNonAlphanumericCharacters; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return _minRequiredPasswordLength; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return _passwordStrengthRegularExpression; }
        }

      
        #endregion Public Propeties

        #region Helper functions

        private static string GetConfigValue(string configValue, string defaultValue)
        {
            return String.IsNullOrEmpty(configValue) ? defaultValue : configValue;
        }

        private MembershipUser GetMembershipUserFromUser(Users usr)
        {
            var u = new MembershipUser(Name,
                usr.Username,
                usr.Id,
                usr.Email,
                usr.PasswordQuestion,
                usr.Comment,
                usr.IsApproved,
                usr.IsLockedOut,
                usr.CreationDate,
                usr.LastLoginDate,
                usr.LastActivityDate,
                usr.LastPasswordChangedDate,
                usr.LastLockedOutDate);
            return u;
        }

        private void UpdateFailureCount(string username, string failureType)
        {
            var windowStart = new DateTime();
            var failureCount = 0;
            try
            {
                var usr = _userService.GetUserByUsernameApplicationName(username, ApplicationName);

                if (usr != null)
                {
                    if (failureType == "password")
                    {
                        failureCount = usr.FailedPasswordAttemptCount;
                        windowStart = usr.FailedPasswordAttemptWindowStart;
                    }

                    if (failureType == "passwordAnswer")
                    {
                        failureCount = usr.FailedPasswordAnswerAttemptCount;
                        windowStart = usr.FailedPasswordAnswerAttemptWindowStart;
                    }
                }

                var windowEnd = windowStart.AddMinutes(PasswordAttemptWindow);

                if (failureCount == 0 || DateTime.Now > windowEnd)
                {
                    if (failureType == "password")
                    {
                        if (usr != null)
                        {
                            usr.FailedPasswordAttemptCount = 1;
                            usr.FailedPasswordAttemptWindowStart = DateTime.Now;
                        }
                        ;
                    }

                    if (failureType == "passwordAnswer")
                    {
                        usr.FailedPasswordAnswerAttemptCount = 1;
                        usr.FailedPasswordAnswerAttemptWindowStart = DateTime.Now;
                        ;
                    }
                    _userService.SaveChanges(usr);
                }
                else
                {
                    if (failureCount++ >= MaxInvalidPasswordAttempts)
                    {
                        if (usr == null) return;
                        usr.IsLockedOut = true;
                        usr.LastLockedOutDate = DateTime.Now;
                        _userService.SaveChanges(usr);
                    }
                    else
                    {
                        if (failureType == "password")
                            if (usr != null) usr.FailedPasswordAttemptCount = failureCount;

                        if (failureType == "passwordAnswer")
                            if (usr != null) usr.FailedPasswordAnswerAttemptCount = failureCount;

                        _userService.SaveChanges(usr);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = dbpassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(dbpassword);
                    break;

                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePassword(password);
                    break;

                default:
                    break;
            }

            return pass1 == pass2;
        }

        private string EncodePassword(string password)
        {
            var encodedPassword = password;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;

                case MembershipPasswordFormat.Encrypted:
                    encodedPassword =
                        Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;

                case MembershipPasswordFormat.Hashed:
                    var hash = new HMACSHA1 { Key = HexToByte(_machineKey.ValidationKey) };
                    encodedPassword =
                        Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    break;

                default:
                    throw new ProviderException("Unsupported password format.");
            }
            return encodedPassword;
        }

        private string UnEncodePassword(string encodedPassword)
        {
            string password = encodedPassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;

                case MembershipPasswordFormat.Encrypted:
                    password =
                        Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                    break;

                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Cannot unencode a hashed password.");
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return password;
        }

        internal byte[] HexToByte(string hexString)
        {
            var returnBytes = new byte[hexString.Length / 2];
            for (var i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        #endregion Helper functions

        #region Private Methods

        private MembershipUser GetMembershipUserByKeyOrUser(bool isKeySupplied, string username, object providerUserKey,
            bool userIsOnline)
        {
            MembershipUser u = null;
            try
            {
                var usr = isKeySupplied
                    ? _userService.GetUserById((Guid)providerUserKey)
                    : _userService.GetUserByUsernameApplicationName(username, ApplicationName);
                if (usr != null)
                {
                    u = GetMembershipUserFromUser(usr);

                    if (userIsOnline)
                    {
                        usr.LastActivityDate = DateTime.Now;
                        _userService.SaveChanges(usr);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return u;
        }

        private Users GetUserByUsername(string username)
        {
            Users usr = null;
            try
            {
                usr = _userService.GetUserByUsernameApplicationName(username, ApplicationName);
            }
            catch (Exception e)
            {
                throw e;
            }

            return usr;
        }

        private IList<Users> GetUsers()
        {
            IList<Users> usrs = null;
            try
            {
                usrs = _userService.GetUsersByApplicationName(ApplicationName);
            }
            catch (Exception e)
            {
                throw e;
            }
            return usrs;
        }

        internal IList<Users> GetUsersLikeUsername(string usernameToMatch)
        {
            IList<Users> usrs = null;
            try
            {
                usrs = null; //_userService.GetUsersLikeUsername(usernameToMatch,ApplicationName);
            }
            catch (Exception e)
            {
                throw e;
            }
            return usrs;
        }

        internal IList<Users> GetUsersLikeEmail(string emailToMatch)
        {
            IList<Users> usrs = null;
            try
            {
                usrs = null; //_userService.GetUsersLikeEmail(emailToMatch, ApplicationName);
            }
            catch (Exception e)
            {
                throw e;
            }
            return usrs;
        }

        #endregion Private Methods

        #region Public methods
        public override void Initialize(string name, NameValueCollection config)
        {
            // Initialize values from web.config.
            if (config == null)
                throw new ArgumentNullException("config");

            if (name.Length == 0)
                name = "MembershipProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sample Fluent Nhibernate Membership provider");
            }
            // Initialize the abstract base class.
            base.Initialize(name, config);

            _applicationName = GetConfigValue(config["applicationName"], HostingEnvironment.ApplicationVirtualPath);
            _maxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
            _passwordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
            _minRequiredNonAlphanumericCharacters =
                Convert.ToInt32(GetConfigValue(config["minRequiredNonAlphanumericCharacters"], "1"));
            _minRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
            _passwordStrengthRegularExpression =
                Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
            _enablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
            _enablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));
            _requiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
            _requiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "true"));
            string temp_format = config["passwordFormat"];
            if (temp_format == null)
            {
                temp_format = "Hashed";
            }

            switch (temp_format)
            {
                case "Hashed":
                    _passwordFormat = MembershipPasswordFormat.Hashed;
                    break;

                case "Encrypted":
                    _passwordFormat = MembershipPasswordFormat.Encrypted;
                    break;

                case "Clear":
                    _passwordFormat = MembershipPasswordFormat.Clear;
                    break;

                default:
                    throw new ProviderException("Password format not supported.");
            }
            // Initialize Connection.
            var connectionStringSettings =
                ConfigurationManager.ConnectionStrings[config["connectionStringName"]];
            if (connectionStringSettings == null || connectionStringSettings.ConnectionString.Trim() == "")
                throw new ProviderException("Connection string cannot be blank.");

            _connectionString = connectionStringSettings.ConnectionString;
            // Get encryption and decryption key information from the configuration.

            //Encryption skipped
            Configuration cfg =
                WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);
            _machineKey = (MachineKeySection)cfg.GetSection("system.web/machineKey");

            if (_machineKey.ValidationKey.Contains("AutoGenerate"))
                if (PasswordFormat != MembershipPasswordFormat.Clear)
                    throw new ProviderException(
                        "Hashed or Encrypted passwords are not supported with auto-generated keys.");
        }

        public override bool ChangePassword(string username, string oldPwd, string newPwd)
        {
            int rowsAffected = 0;
            Users usr = null;
            if (!ValidateUser(username, oldPwd))
                return false;
            var args = new ValidatePasswordEventArgs(username, newPwd, true);
            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException(
                        "Change password canceled due to new password validation failure.");
            try
            {
                usr = GetUserByUsername(username);

                if (usr != null)
                {
                    usr.Password = EncodePassword(newPwd);
                    usr.LastPasswordChangedDate = DateTime.Now;
                    _userService.SaveChanges(usr);
                    rowsAffected = 1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            if (rowsAffected > 0)
                return true;
            return false;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username,
            string password,
            string newPwdQuestion,
            string newPwdAnswer)
        {
            Users usr = null;
            int rowsAffected = 0;
            if (!ValidateUser(username, password))
                return false;
            try
            {
                usr = GetUserByUsername(username);
                if (usr != null)
                {
                    usr.PasswordQuestion = newPwdQuestion;
                    usr.PasswordAnswer = newPwdAnswer;
                    _userService.SaveChanges(usr);

                    rowsAffected = 1;
                }
            }
            catch (OdbcException e)
            {
                throw e;
            }

            if (rowsAffected > 0)
                return true;
            return false;
        }

        // Create a new Membership user
        public override MembershipUser CreateUser(string username,
            string password,
            string email,
            string passwordQuestion,
            string passwordAnswer,
            bool isApproved,
            object providerUserKey,
            out MembershipCreateStatus status)
        {
            var args = new ValidatePasswordEventArgs(username, password, true);

            OnValidatingPassword(args);
            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != "")
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            MembershipUser u = GetUser(username, false);

            if (u == null)
            {
                DateTime createDate = DateTime.Now;
                var user = new Users();
                user.Username = username;
                user.Password = EncodePassword(password);
                user.Email = email;
                //  user.PasswordQuestion = passwordQuestion;
                //  user.PasswordAnswer = EncodePassword(passwordAnswer);
                user.IsApproved = isApproved;
                user.Comment = "";
                user.CreationDate = createDate;
                user.LastPasswordChangedDate = createDate;
                user.LastActivityDate = createDate;
                user.ApplicationName = _applicationName;
                user.IsLockedOut = false;
                user.LastLockedOutDate = createDate;
                user.FailedPasswordAttemptCount = 0;
                user.FailedPasswordAttemptWindowStart = createDate;
                user.FailedPasswordAnswerAttemptCount = 0;
                user.FailedPasswordAnswerAttemptWindowStart = createDate;
                user.LastLoginDate = createDate;
                try
                {
                    _userService.Save(user);
                    int retId = 1;

                    if ((retId < 1))
                        status = MembershipCreateStatus.UserRejected;
                    else
                        status = MembershipCreateStatus.Success;
                }
                catch (Exception e)
                {
                    status = MembershipCreateStatus.ProviderError;
                    throw e;
                }
                //retrive and return user by user name
                return GetUser(username, false);
            }
            status = MembershipCreateStatus.DuplicateUserName;
            return null;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            int rowsAffected = 0;
            Users usr = null;
            try
            {
                usr = GetUserByUsername(username);
                if (usr != null)
                {
                    _userService.Delete(usr.Id);

                    rowsAffected = 1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            if (rowsAffected > 0)
                return true;
            return false;
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            var users = new MembershipUserCollection();
            totalRecords = 0;
            IList<Users> allusers = null;
            int counter = 0;
            int startIndex = pageSize * pageIndex;
            int endIndex = startIndex + pageSize - 1;
            try
            {
                totalRecords = 1000; // _userService.GetTotalRecord(ApplicationName);

                if (totalRecords <= 0)
                {
                    return users;
                }

                allusers = GetUsers();
                foreach (Users u in allusers)
                {
                    if (counter >= endIndex)
                        break;
                    if (counter >= startIndex)
                    {
                        MembershipUser mu = GetMembershipUserFromUser(u);
                        users.Add(mu);
                    }
                    counter++;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return users;
        }

        public override int GetNumberOfUsersOnline()
        {
            var onlineSpan = new TimeSpan(0, Membership.UserIsOnlineTimeWindow, 0);
            DateTime compareTime = DateTime.Now.Subtract(onlineSpan);
            int numOnline = 0;
            try
            {
                numOnline = 100; // _userService.GetTotalOnlineUsers(ApplicationName, compareTime);
            }
            catch (Exception e)
            {
                throw e;
            }
            return numOnline;
        }

        public override string GetPassword(string username, string answer)
        {
            string password = string.Empty;
            string passwordAnswer = string.Empty;

            if (!EnablePasswordRetrieval)
                throw new ProviderException("Password Retrieval Not Enabled.");

            if (PasswordFormat == MembershipPasswordFormat.Hashed)
                throw new ProviderException("Cannot retrieve Hashed passwords.");

            try
            {
                Users usr = GetUserByUsername(username);

                if (usr == null)
                    throw new MembershipPasswordException("The supplied user name is not found.");
                if (usr.IsLockedOut)
                    throw new MembershipPasswordException("The supplied user is locked out.");

                password = usr.Password;
                passwordAnswer = usr.PasswordAnswer;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
            {
                UpdateFailureCount(username, "passwordAnswer");
                throw new MembershipPasswordException("Incorrect password answer.");
            }

            if (PasswordFormat == MembershipPasswordFormat.Encrypted)
                password = UnEncodePassword(password);

            return password;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return GetMembershipUserByKeyOrUser(false, username, 0, userIsOnline);
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            return GetMembershipUserByKeyOrUser(true, string.Empty, providerUserKey, userIsOnline);
        }

        public override bool UnlockUser(string username)
        {
            Users usr = null;
            bool unlocked = false;
            try
            {
                usr = GetUserByUsername(username);

                if (usr != null)
                {
                    usr.LastLockedOutDate = DateTime.Now;
                    usr.IsLockedOut = false;
                    _userService.SaveChanges(usr);

                    unlocked = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return unlocked;
        }

        public override string GetUserNameByEmail(string email)
        {
            Users usr = null;
            try
            {
                usr = null; // _userService.GetUserByEmailApplicationName(email, ApplicationName);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (usr == null)
                return string.Empty;
            return usr.Username;
            ;
        }

        public override string ResetPassword(string username, string answer)
        {
            int rowsAffected = 0;
            Users usr = null;

            if (!EnablePasswordReset)
                throw new NotSupportedException("Password reset is not enabled.");

            if (answer == null && RequiresQuestionAndAnswer)
            {
                UpdateFailureCount(username, "passwordAnswer");
                throw new ProviderException("Password answer required for password reset.");
            }

            string newPassword =
                Membership.GeneratePassword(NewPasswordLength, MinRequiredNonAlphanumericCharacters);

            var args = new ValidatePasswordEventArgs(username, newPassword, true);

            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("Reset password canceled due to password validation failure.");

            string passwordAnswer = "";

            try
            {
                usr = GetUserByUsername(username);
                if (usr == null)
                    throw new MembershipPasswordException("The supplied user name is not found.");

                if (usr.IsLockedOut)
                    throw new MembershipPasswordException("The supplied user is locked out.");

                if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
                {
                    UpdateFailureCount(username, "passwordAnswer");
                    throw new MembershipPasswordException("Incorrect password answer.");
                }

                usr.Password = EncodePassword(newPassword);
                usr.LastPasswordChangedDate = DateTime.Now;
                usr.Username = username;
                usr.ApplicationName = ApplicationName;
                _userService.SaveChanges(usr);

                rowsAffected = 1;
            }
            catch (OdbcException e)
            {
                throw e;
            }
            if (rowsAffected > 0)
                return newPassword;
            throw new MembershipPasswordException("User not found, or user is locked out. Password not Reset.");
        }

        public override void UpdateUser(MembershipUser user)
        {
            Users usr = null;
            try
            {
                usr = GetUserByUsername(user.UserName);
                if (usr != null)
                {
                    usr.Email = user.Email;
                    usr.Comment = user.Comment;
                    usr.IsApproved = user.IsApproved;
                    _userService.SaveChanges(usr);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            Users usr = null;
            try
            {
                usr = GetUserByUsername(username);
                if (usr == null)
                    return false;
                if (usr.IsLockedOut)
                    return false;

                if (CheckPassword(password, usr.Password))
                {
                    if (usr.IsApproved)
                    {
                        isValid = true;
                        usr.LastLoginDate = DateTime.Now;
                        _userService.SaveChanges(usr);
                    }
                }
                else
                    UpdateFailureCount(username, "password");
            }
            catch (Exception e)
            {
                throw e;
            }
            return isValid;
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            IList<Users> allusers = null;
            var users = new MembershipUserCollection();
            int counter = 0;
            int startIndex = pageSize * pageIndex;
            int endIndex = startIndex + pageSize - 1;
            totalRecords = 0;
            try
            {
                allusers = GetUsersLikeUsername(usernameToMatch);
                if (allusers == null)
                    return users;
                if (allusers.Count > 0)
                    totalRecords = allusers.Count;
                else
                    return users;

                foreach (Users u in allusers)
                {
                    if (counter >= endIndex)
                        break;
                    if (counter >= startIndex)
                    {
                        MembershipUser mu = GetMembershipUserFromUser(u);
                        users.Add(mu);
                    }
                    counter++;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return users;
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            IList<Users> allusers = null;
            var users = new MembershipUserCollection();
            int counter = 0;
            int startIndex = pageSize * pageIndex;
            int endIndex = startIndex + pageSize - 1;
            totalRecords = 0;

            try
            {
                allusers = GetUsersLikeEmail(emailToMatch);
                if (allusers == null)
                    return users;
                if (allusers.Count > 0)
                    totalRecords = allusers.Count;
                else
                    return users;

                foreach (Users u in allusers)
                {
                    if (counter >= endIndex)
                        break;
                    if (counter >= startIndex)
                    {
                        MembershipUser mu = GetMembershipUserFromUser(u);
                        users.Add(mu);
                    }
                    counter++;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return users;
        }

        #endregion Public methods
    }
}