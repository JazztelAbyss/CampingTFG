using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmailController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public EmailController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpPost]
		public IActionResult SendEmail(string content)
		{
			try
			{
				var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
				{
					Port = int.Parse(_configuration["Smtp:Port"]),
					Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
					EnableSsl = true,
				};

				var mailMessage = new MailMessage
				{
					From = new MailAddress(_configuration["Smtp:From"]),
					Subject = "Aviso de CampSiteBySide",
					Body = content,
					IsBodyHtml = true
				};

				mailMessage.To.Add("misape575@gmail.com");

				smtpClient.Send(mailMessage);
				return Ok("Email sent successfully");
			}
			catch
			{
				throw;
			}
		}
	}
}
