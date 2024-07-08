namespace CampingWebAssembly.Services.Interfaces
{
	public interface IEmailService
	{
		Task SendEmailAsync(string content);
	}
}
