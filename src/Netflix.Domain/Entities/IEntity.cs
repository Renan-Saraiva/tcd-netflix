using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Domain.Entities
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
