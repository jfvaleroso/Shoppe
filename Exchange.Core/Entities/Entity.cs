using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }
    }
}
