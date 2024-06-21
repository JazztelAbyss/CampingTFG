using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ImageCamping
    {
        public string Id { get; set; } = new Guid().ToString();

        [Required]
        public string CampingId { get; set; } = string.Empty;

        [Required]
        public byte[] Image { get; set; } = new byte[Constants.MAX_IMG_SIZE];
    }
}
