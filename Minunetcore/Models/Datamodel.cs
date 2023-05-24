using System.ComponentModel.DataAnnotations;

namespace Minunetcore.Models
{
    public class Datamodel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string ProductName { get; set; }

    }
}
