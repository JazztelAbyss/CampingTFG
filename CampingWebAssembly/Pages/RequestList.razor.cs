﻿using DAL.Models;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
	public partial class RequestList
	{
		public User? LoggedUser { get; set; }
		public List<Request> Requests { get; set; } = new();

		public class RequestCard
		{
			public string UserMail = string.Empty;
			public DateTime Start = DateTime.Now;
			public DateTime End = DateTime.Now;
			public byte[] Image = Array.Empty<byte>();
		}

		public List<RequestCard> DisplayRequests { get; set; } = new();

		protected override async Task OnInitializedAsync()
		{
			LoggedUser = AuthService.GetLoggedUser();
			if(LoggedUser != null)
			{
				Requests = await Http.GetFromJsonAsync<List<Request>>("api/Request");
				Requests = Requests.FindAll(r => r.ResponsibleId == LoggedUser.Id);
				if(Requests.Count > 0) { await GetDependencies(Requests); }
			}
		}

		protected async Task<string> GetUserMail(string id)
		{
			var user = await Http.GetFromJsonAsync<User>("api/User/" + id);
			if (user != null)
			{
				return user.Mail;
			}
			else return "Correo privado";			
		}

		protected async Task<byte[]> GetCampingImage(string id)
		{
			var camping = await Http.GetFromJsonAsync<Camping>("api/Camping/" + id);
			if (camping != null)
			{
				return camping.Portrait;
			}
			else return Array.Empty<byte>();
		}

		protected async Task GetDependencies(List<Request> requests)
		{
			foreach (var request in requests)
			{
				DisplayRequests.Add(new RequestCard
				{
					UserMail = await GetUserMail(request.UserId),
					Start = request.Start,
					End = request.End,
					Image = await GetCampingImage(request.CampingId)
				});
			}
		}
	}
}
