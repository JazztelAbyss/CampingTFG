using BlazorBootstrap;
using DAL.Models;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
    public partial class Comparator
    {
        private List<Camping> campings { get; set; } = new();

        private Modal comparationModal = default!;

		private Camping? camping1 {  get; set; }
		private Camping? camping2 {  get; set; }

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

		protected void CheckCamping(bool column, Camping c)
		{
			if (column)
			{
				camping1 = c;
			}
			else camping2 = c;
		}
	}
}
