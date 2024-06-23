using DAL.Models;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
	public partial class RequestListUser
	{
		public User? LoggedUser { get; set; }
		public List<Request> Requests { get; set; } = new();

		public class RequestCard
		{
			public int RequestRef { get; set; }
			public string CampingName = string.Empty;
			public DateTime Start = DateTime.Now;
			public DateTime End = DateTime.Now;
			public byte[] Image = Array.Empty<byte>();
		}

		public List<RequestCard> DisplayRequests { get; set; } = new();
		public List<RequestCard> AcceptedRequests { get; set; } = new();
		public List<RequestCard> RejectedRequests { get; set; } = new();

		protected override async Task OnInitializedAsync()
		{
			LoggedUser = AuthService.GetLoggedUser();
			if(LoggedUser != null)
			{
				Requests = await Http.GetFromJsonAsync<List<Request>>("api/Request");
				Requests = Requests.FindAll(r => r.UserId == LoggedUser.Id);
				if(Requests.Count > 0) 
				{
					await GetDependencies(Requests);
				}
			}
		}

		protected async Task<string> GetCampingName(string id)
		{
			var camping = await Http.GetFromJsonAsync<Camping>("api/Camping/" + id);
			if (camping != null)
			{
				return camping.Name;
			}
			else return "Error desconocido";			
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
				if(request.Status == "Pendiente")
				{
					DisplayRequests.Add(new RequestCard
					{
						RequestRef = Requests.IndexOf(request),
						CampingName = await GetCampingName(request.CampingId),
						Start = request.Start,
						End = request.End,
						Image = await GetCampingImage(request.CampingId)
					});
				}
				else if(request.Status == "Aceptada")
				{
					AcceptedRequests.Add(new RequestCard
					{
						RequestRef = Requests.IndexOf(request),
						CampingName = await GetCampingName(request.CampingId),
						Start = request.Start,
						End = request.End,
						Image = await GetCampingImage(request.CampingId)
					});
				}
			}
		}
	}
}
