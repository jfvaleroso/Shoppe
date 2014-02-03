using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exchange.Core.Entities;

namespace Exchange.Web.Models
{
    public class UserModel
    {
        public IList<Users> GetUsers { get; set; }
        public string name { get; set; }
    }
}