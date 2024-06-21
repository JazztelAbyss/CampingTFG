using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TagHolder
    {
        [Required]
        public string CampingId { get; set; } = string.Empty;

        [Required]
        public int ServiceId { get; set; }
    }
}
