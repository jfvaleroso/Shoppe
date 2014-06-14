using Exchange.Core.Entities;
using FluentNHibernate.Mapping;

namespace Exchange.NHibernateBase.Mapping
{
    public class NoteMap : ClassMap<Note>
    {
        public NoteMap()
        {
            Table("Note");
            Id(x => x.Id);
            Map(x => x.Description);
            Map(x => x.Date);
            Map(x => x.Cashier);
            References(x => x.Invoice);
        }
    }
}