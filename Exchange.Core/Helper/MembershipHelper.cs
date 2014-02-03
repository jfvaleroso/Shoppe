using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.Configuration;
using Exchange.Core.Entities;

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
                DateTime creationDate = (DateTime)u.CreationDate;
                DateTime lastLoginDate = new DateTime();
                if (u.LastLoginDate != null)
                {
                    lastLoginDate = (DateTime)u.LastLoginDate;
                }
                DateTime lastActivityDate = new DateTime();
                if (u.LastActivityDate != null)
                {
                    lastActivityDate = (DateTime)u.LastActivityDate;
                }
                DateTime lastPasswordChangedDate = new DateTime();
                if (u.LastPasswordChangedDate != null)
                {
                    lastPasswordChangedDate = (DateTime)u.LastPasswordChangedDate;
                }
                DateTime lastLockedOutDate = new DateTime();
                if (u.LastLockedOutDate != null)
                {
                    lastLockedOutDate = (DateTime)u.LastLockedOutDate;
                }

                MembershipUser membershipUser = new MembershipUser(
                  name,
                 u.Username,
                 (object)u.Id,
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
            public int newPasswordLength;
            public string applicationName;
            public bool enablePasswordReset;
            public bool enablePasswordRetrieval;
            public bool requiresQuestionAndAnswer;
            public bool requiresUniqueEmail;
            public int maxInvalidPasswordAttempts;
            public int passwordAttemptWindow;
            public MembershipPasswordFormat passwordFormat;
            public int minRequiredNonAlphanumericCharacters;
            public int minRequiredPasswordLength;
            public string passwordStrengthRegularExpression;
            public MachineKeySection machineKey;
            public string providerName;
        }

   
}
