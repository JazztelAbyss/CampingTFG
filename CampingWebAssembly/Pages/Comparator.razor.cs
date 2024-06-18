using DAL.Models;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
    public partial class Comparator
    {
        private List<Camping> campings { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await GetCampings();
        }

		protected async Task GetCampings()
		{
			campings = await Http.GetFromJsonAsync<List<Camping>>("api/Camping");
		}
	}
}
