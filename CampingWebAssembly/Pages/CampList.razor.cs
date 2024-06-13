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

		//Filtros de busqueda
		string name = "";
		IEnumerable<int> price = [25, 75];
		int locality = 0;
		IEnumerable<int> people = [25, 75];

		protected override async Task OnInitializedAsync()
		{
			await GetCampings();
		}

		protected async Task GetCampings()
		{
			campings = await Http.GetFromJsonAsync<List<Camping>>("api/Camping");
			filteredCampings = campings;
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
