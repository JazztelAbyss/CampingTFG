using CampingWebAssembly.Services.Interfaces;
using System.Net.Http.Json;

namespace CampingWebAssembly.Services
{
	public class EmailService : IEmailService
	{
		private readonly HttpClient _httpClient;

		public EmailService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task SendEmailAsync(string content)
		{
			var response = await _httpClient.PostAsJsonAsync("api/Email", content);
			response.EnsureSuccessStatusCode();
		}
	}
}
