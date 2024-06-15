using Microsoft.AspNetCore.Components;
using DAL.Models;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
	public partial class Details
	{
		[Parameter]
		public string? Id { get; set; }

		public Camping? Camp { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await GetCamping();
		}

		protected async Task GetCamping()
		{
			Camp = await Http.GetFromJsonAsync<Camping>("api/Camping/" + Id);
		}
	}
}
