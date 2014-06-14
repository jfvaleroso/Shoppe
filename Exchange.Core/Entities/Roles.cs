using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exchange.Core.Entities
{
    public class Roles : Entity<Guid>
    {
        public Roles()
        {
            UsersInRole = new List<Users>();
        }

        [Required]
        public virtual string RoleName { get; set; }

        public virtual string ApplicationName { get; set; }

        [Required]
        public virtual string Description { get; set; }

        public virtual IList<Users> UsersInRole { get; set; }
    }
}