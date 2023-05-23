using System.ComponentModel.DataAnnotations;

namespace Minunetcore.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(70)]
        public string Description { get; set; }
    }
}
