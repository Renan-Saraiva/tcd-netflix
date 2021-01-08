using System.ComponentModel.DataAnnotations;

namespace Netflix.Domain.Domain
{
    public class MovieCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Rate { get; set; }
    }
}
