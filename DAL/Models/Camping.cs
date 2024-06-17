using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace DAL.Models
{
    public class Camping
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public byte[] Portrait {  get; set; } = new byte[Constants.MAX_IMG_SIZE];

        [Required]
        public double CoordX { get; set; }

        [Required]
        public double CoordY { get; set; }

        [Required]
        [StringLength(20)]
        public string Locality {  get; set; } = string.Empty;

        [Required]
        public double Price { get; set; }

        [Required]
        public int Capacity { get; set; }

        public double Rating { get; set; } = 0;

    }
}
