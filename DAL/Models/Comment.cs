using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class Comment
	{
		[Required]
		public string UserId { get; set; } = string.Empty;

		[Required]
		public string CampingId { get; set; } = string.Empty;

		public string? Content {  get; set; }

		[Required]
		[Range(0, 5)]
		public int Ratings { get; set; }
	}
}
