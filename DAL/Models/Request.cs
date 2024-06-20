using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Request
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string ResponsibleId { get; set; } = string.Empty;

        [Required]
        public string CampingId {  get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Pendiente";

        [Required]
        public DateTime Start {  get; set; }

        [Required]
        public DateTime End { get; set; }
    }
}
