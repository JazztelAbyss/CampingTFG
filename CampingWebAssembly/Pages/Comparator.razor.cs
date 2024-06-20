using BlazorBootstrap;
using DAL.Models;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
    public partial class Comparator
    {
        private List<Camping> campings { get; set; } = new();

        private Modal comparationModal = default!;

        protected override async Task OnInitializedAsync()
        {
            await GetCampings();
        }

		private async Task OnShowModalClick()
		{
			await comparationModal.ShowAsync();
		}

		protected async Task GetCampings()
		{
			campings = await Http.GetFromJsonAsync<List<Camping>>("api/Camping");
		}
	}
}
