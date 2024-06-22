using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public byte[] Icon { get; set; } = new byte[Constants.MAX_IMG_SIZE];

		public override bool Equals(object? obj)
		{
			if(obj is Service service)
			{
				return this.Id == service.Id && this.Icon == service.Icon;
			}
			return false;
		}
	}
}
