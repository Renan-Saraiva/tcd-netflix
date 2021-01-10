using System;
using System.Collections.Generic;
using System.Text;
using Netflix.Domain.Enum;

namespace Netflix.Domain.Entities
{
    public class Movie : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MovieStatus Status { get; set; }
        public long ViewedCount { get; set; }
        public MovieCategory Category { get; set; }
    }
}
