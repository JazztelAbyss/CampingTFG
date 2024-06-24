using BlazorBootstrap;
using DAL.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
    public partial class Comparator
    {
        private List<Camping> campings1 { get; set; } = new();
		private List<Camping> campings2 { get; set; } = new();

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
			campings1 = await Http.GetFromJsonAsync<List<Camping>>("api/Camping");
			campings2 = await Http.GetFromJsonAsync<List<Camping>>("api/Camping");
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
			Camping1Has = Camp1Services.Where(s => Camp2Services.Find(s2 => s2.Id == s.Id) == null).ToList();
			Camping2Has = Camp2Services.Where(s => Camp1Services.Find(s2 => s2.Id == s.Id) == null).ToList();
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

		protected void ShowFirst1(ChangeEventArgs args)
		{
			if(args.Value != null)
			{
				var newFirst = campings1.First(c => c.Name.Contains((string)args.Value));
				campings1.Remove(newFirst);
				campings1.Insert(0, newFirst);
			}
		}

		protected void ShowFirst2(ChangeEventArgs args)
		{
			if (args.Value != null)
			{
				var newFirst = campings2.First(c => c.Name.Contains((string)args.Value));
				campings2.Remove(newFirst);
				campings2.Insert(0, newFirst);
			}
		}
	}
}
