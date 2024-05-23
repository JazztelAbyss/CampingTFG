using System.ComponentModel.DataAnnotations;

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

        public byte[] Pic { get; set; } = new byte[Constants.MAX_IMG_SIZE];

        [Required]
        public bool IsResponsible { get; set; }
    }
}
