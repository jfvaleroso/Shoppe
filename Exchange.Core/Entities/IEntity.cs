using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Primary key of the entity.
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}
