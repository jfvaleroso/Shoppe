using System;
using System.Web.Profile;
using System.Web.Security;

namespace Exchange.Providers
{
    public class UserProfileBase : ProfileBase
    {
        public static UserProfileBase GetUserProfile(string username)
        {
            return (UserProfileBase)ProfileBase.Create(username, true);
        }

        public static UserProfileBase GetUserProfile()
        {
            MembershipUser membershipUser = Membership.GetUser();
            if (membershipUser != null)
            {
                return (UserProfileBase)ProfileBase.Create(membershipUser.UserName);
            }
            return new UserProfileBase();
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
        public string MiddleName
        {
            get { return base["MiddleName"] as string; }

            set { base["MiddleName"] = value; }
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
        [SettingsAllowAnonymous(false)]
        public Guid UserId
        {
            get { return base["UserId"] is Guid ? (Guid) base["UserId"] : new Guid(); }

            set { base["UserId"] = value; }
        }

        #endregion profile
    }
}