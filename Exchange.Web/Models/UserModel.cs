using Exchange.Core.Entities;
using System.Collections.Generic;

namespace Exchange.Web.Models
{
    public class UserModel
    {
        public IList<Users> GetUsers { get; set; }

        public string name { get; set; }
    }
}