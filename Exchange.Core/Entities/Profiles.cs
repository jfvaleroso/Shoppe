
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Exchange.Core.Entities
{
    public class Profiles : Entity<int>
    {
      
        
        public virtual string ApplicationName { get; set; }
        public virtual bool IsAnonymous { get; set; }
        public virtual DateTime LastActivityDate { get; set; }
        public virtual DateTime LastUpdatedDate { get; set; }
        public virtual string Subscription { get; set; }
        public virtual string Language { get; set; }

        public virtual string Gender { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Position { get; set; }
        public virtual string Address { get; set; }
        public virtual int Users_Id { get; set; }
    
      
        
        public Profiles()
        {
            LastActivityDate = DateTime.MinValue;
            LastUpdatedDate = DateTime.MinValue;
            BirthDate = DateTime.MinValue;
        
        }
    }
}