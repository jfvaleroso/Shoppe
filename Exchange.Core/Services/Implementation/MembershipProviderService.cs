using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Services.IServices;
using Exchange.Core.Repositories;
using System.Web.Security;

namespace Exchange.Core.Services.Services
{
    public class MembershipProviderService : IMembershipProviderService
    {
        private readonly IMembershipProviderRepository membershipProviderRepository;
        public MembershipProviderService(IMembershipProviderRepository membershipProviderRepository)
	    {
            this.membershipProviderRepository = membershipProviderRepository;
	    }

        public bool ValidateUser(string username, string password)
        {
            return this.membershipProviderRepository.ValidateUser(username, password);
        }


        public MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, out MembershipCreateStatus status)
        {
            return this.membershipProviderRepository.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, out status);
        }





        public MembershipUser GetUser(string username)
        {
            return this.membershipProviderRepository.GetUser(username);
        }

        public void UpdateUser(MembershipUser membershipUser)
        {
            this.membershipProviderRepository.UpdateUser(membershipUser);
        }
    }
}
