using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exchange.Core.Entities
{
    public class Roles : Entity<Guid>
    {
      
        [Required]
        public virtual string RoleName { get; set; }
        public virtual string ApplicationName { get; set; }
         [Required]
        public virtual string Description { get; set; }
        public virtual IList<Users> UsersInRole { get; set; }

        public Roles()
        {
            UsersInRole = new List<Users>();
        }

    }
}