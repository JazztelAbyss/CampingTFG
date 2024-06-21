using DAL.Models;
using Radzen;
using Radzen.Blazor;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
	public partial class Map
	{
		private RadzenGoogleMap map;

		public List<Camping> Campings { get; set; } = new();
		private Camping? SelectedCamping { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await GetCampings();	
		}

		protected async Task GetCampings()
		{
			Campings = await Http.GetFromJsonAsync<List<Camping>>("api/Camping");
		}

		protected void OnMarkerClick(RadzenGoogleMapMarker marker)
		{
			SelectedCamping = Campings.Find(c => c.Id == marker.Title);
		}
	}
}
