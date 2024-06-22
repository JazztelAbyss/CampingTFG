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

		private bool IsCheaper { get; set; } = false;
		private bool IsBigger { get; set; } = false;

		private List<Service> Camping1Has { get; set; } = new();
		private List<Service> Camping2Has {  get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await GetCampings();
        }

		private async Task OnShowModalClick()
		{
            await Compare();
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

		protected async Task Compare()
		{
			IsCheaper = camping1!.Price < camping2!.Price;
			IsBigger = camping1!.Capacity > camping2!.Capacity;
			var Camp1Services = await GetServices(camping1.Id);
			var Camp2Services = await GetServices(camping2.Id);
			Camping1Has = Camp1Services.Except(Camp2Services).ToList();
			Camping2Has = Camp2Services.Except(Camp1Services).ToList();
		}

		protected async Task<List<Service>> GetServices(string campingId)
		{
			var Services = new List<Service>();
            var Tags = await Http.GetFromJsonAsync<List<TagHolder>>("api/TagHolder/" + campingId);
            if (Tags != null)
            {
                foreach (TagHolder tag in Tags)
                {
                    var service = await Http.GetFromJsonAsync<Service>("api/Service/" + tag.ServiceId.ToString());
                    if (service != null)
                    {
                        Services.Add(service);
                    }
                }
            }
			return Services;
        }
	}
}
