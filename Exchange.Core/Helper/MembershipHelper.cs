using Exchange.Core.Entities;
using System;
using System.Web.Configuration;
using System.Web.Security;

namespace Exchange.Core.Helper
{
    public enum FailureType
    {
        Password = 1,
        PasswordAnswer = 2
    }

    public static class MembershipHelper
    {
        public static MembershipUser GetUserFromObject(Users u, string name)
        {
            DateTime creationDate = u.CreationDate;
            var lastLoginDate = new DateTime();
            if (u.LastLoginDate != null)
            {
                lastLoginDate = u.LastLoginDate;
            }
            var lastActivityDate = new DateTime();
            if (u.LastActivityDate != null)
            {
                lastActivityDate = u.LastActivityDate;
            }
            var lastPasswordChangedDate = new DateTime();
            if (u.LastPasswordChangedDate != null)
            {
                lastPasswordChangedDate = u.LastPasswordChangedDate;
            }
            var lastLockedOutDate = new DateTime();
            if (u.LastLockedOutDate != null)
            {
                lastLockedOutDate = u.LastLockedOutDate;
            }

            var membershipUser = new MembershipUser(
                name,
                u.Username,
                u.Id,
                u.Email,
                u.PasswordQuestion,
                u.Comment,
                u.IsApproved,
                u.IsLockedOut,
                creationDate,
                lastLoginDate,
                lastActivityDate,
                lastPasswordChangedDate,
                lastLockedOutDate
                );
            return membershipUser;
        }
    }

    public struct MembershipConfig
    {
        public string applicationName;
        public bool enablePasswordReset;
        public bool enablePasswordRetrieval;
        public MachineKeySection machineKey;
        public int maxInvalidPasswordAttempts;
        public int minRequiredNonAlphanumericCharacters;
        public int minRequiredPasswordLength;
        public int newPasswordLength;
        public int passwordAttemptWindow;
        public MembershipPasswordFormat passwordFormat;
        public string passwordStrengthRegularExpression;
        public string providerName;
        public bool requiresQuestionAndAnswer;
        public bool requiresUniqueEmail;
    }
}