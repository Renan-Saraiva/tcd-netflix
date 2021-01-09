using System;
using System.ComponentModel.DataAnnotations;

namespace Netflix.Domain.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
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
