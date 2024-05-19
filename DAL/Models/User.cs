using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace DAL.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Mail { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Password {  get; set; } = string.Empty;

        public Blob Pic { get; set; }
    }
}
