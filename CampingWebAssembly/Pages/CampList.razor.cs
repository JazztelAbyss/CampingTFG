using DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
    public partial class CampList
    {
        public bool showSearchMenu = false;
		protected List<Camping> campings = new();
		protected List<Camping> filteredCampings = new();

		public class CampingCard
		{
			public string name { get; set; } = string.Empty;
			public byte[] Image { get; set; } = Array.Empty<byte>();
			public string Locality {  get; set; } = string.Empty;
			public double price { get; set; }
			public List<Service> Services { get; set; } = new();
			public string CampingId { get; set; } = string.Empty;
		}

		public List<CampingCard> CampingCards {  get; set; } = new();

		//Filtros de busqueda
		string name = "";
		IEnumerable<int> price = [25, 75];
		int locality = 0;
		IEnumerable<int> people = [25, 75];

		protected override async Task OnInitializedAsync()
		{
			await GetCampings();
			await GetCards();
		}

		protected async Task GetCampings()
		{
			campings = await Http.GetFromJsonAsync<List<Camping>>("api/Camping");
			filteredCampings = campings;
		}

		protected async Task GetCards()
		{
			foreach(var camping in campings)
			{
				CampingCards.Add(new CampingCard
				{
					name = camping.Name,
					Image = camping.Portrait,
					Locality = camping.Locality,
					price = camping.Price,
					Services = await GetServices(camping.Id),
					CampingId = camping.Id
				});
			}
		}

		protected async Task<List<Service>> GetServices(string campingId)
		{
			var tags = await Http.GetFromJsonAsync<List<TagHolder>>("api/TagHolder/" + campingId);
			List<Service> services = new List<Service>();
			if(tags != null)
			{
				foreach(var tag in tags)
				{
					var service = await Http.GetFromJsonAsync<Service>("api/Service/" + tag.ServiceId.ToString());
					if(service != null) {  services.Add(service); }
				}
			}
			return services;
		}

		private void showSearch()
        {
            showSearchMenu = !showSearchMenu;
        }

		protected void SearchCamps()
		{
			FilterByName();
			FilterByPrice();
			FilterByLocality();
		}

		protected void FilterByName()
		{
			if (!name.IsNullOrEmpty())
			{
				filteredCampings = filteredCampings.FindAll(x => x.Name == name);
			}
		}

		protected void FilterByPrice()
		{
			filteredCampings = filteredCampings.FindAll(x =>
			price.First() <= x.Price &&
			x.Price <= price.Last());
		}

		protected void FilterByLocality()
		{
			switch (locality)
			{
				case 1:
					filteredCampings = filteredCampings.FindAll(x => x.Locality.Equals("Valencia"));
					break;
				case 2:
					filteredCampings = filteredCampings.FindAll(x => x.Locality.Equals("Castellón"));
					break;
				case 3:
					filteredCampings = filteredCampings.FindAll(x => x.Locality.Equals("Alicante"));
					break;
				default:
					break;
			}
		}
    }
}
