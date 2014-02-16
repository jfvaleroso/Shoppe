using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class CustomerMap: ClassMap<Customer>
    {
        public CustomerMap()
        {

            Table("Customer");
            Id(x => x.Id);
            Map(x => x.LastName);
            Map(x => x.FirstName);
            Map(x => x.MiddleName);
            Map(x => x.TelephoneNo);
            Map(x => x.CellphoneNo);
            Map(x => x.Email);
            Map(x => x.BirthDate);
            Map(x => x.Gender);
            Map(x => x.OfficeAddress);
            Map(x => x.ResidentialAddress);
            Map(x => x.PostalCode);
            Map(x => x.City);
            Map(x => x.Province);
            Map(x => x.TypeOfID);
            Map(x => x.IDNo);
            Map(x => x.Active);
            Map(x => x.DateCreated);
            Map(x => x.CreatedBy);
            Map(x => x.DateModified);
            Map(x => x.ModifiedBy);
            HasMany(x => x.Invoices)
                .Inverse()
                .Cascade.All();
          
            
         
        }
    }
}
