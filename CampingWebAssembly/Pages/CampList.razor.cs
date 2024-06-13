using DAL.Models;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
    public partial class CampList
    {
        public bool showSearchMenu = false;
		protected List<Camping> campings = new();
		protected List<Camping> filteredCampings = new();
        public double priceValue = 0.00;

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
    }
}
