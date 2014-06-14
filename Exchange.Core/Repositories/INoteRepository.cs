using Exchange.Core.Entities;
using System;

namespace Exchange.Core.Repositories
{
    public interface INoteRepository : IRepository<Note, Guid>
    {
    }
}