using System;
using System.ComponentModel.DataAnnotations;

namespace Netflix.Domain.Entities
{
    public class MovieCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Rate { get; set; }
    }
}
