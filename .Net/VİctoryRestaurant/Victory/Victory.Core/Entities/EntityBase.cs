using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public int Id { get; set; }

        public virtual DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public virtual bool IsActive { get; set; } = true;


    }
}
