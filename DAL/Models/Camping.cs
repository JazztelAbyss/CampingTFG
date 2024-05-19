using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace DAL.Models
{
    public class Camping
    {
        public string Id = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public Blob Portrait {  get; set; }

        [Required]
        public float CoordX { get; set; }

        [Required]
        public float CoordY { get; set; }

    }
}
