using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace DAL.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public Blob Icon { get; set; }
    }
}
