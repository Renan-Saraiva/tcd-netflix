using System;
using System.ComponentModel.DataAnnotations;

namespace Netflix.Domain.Entities
{
    public class Ticket : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Protocol { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
