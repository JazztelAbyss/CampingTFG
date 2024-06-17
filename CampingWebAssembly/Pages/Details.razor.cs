using Microsoft.AspNetCore.Components;
using DAL.Models;
using System.Net.Http.Json;
using Microsoft.JSInterop;

namespace CampingWebAssembly.Pages
{
	public partial class Details
	{
		[Parameter]
		public string? Id { get; set; }
		public Camping? Camp { get; set; }
        const string carouselName = "carouselExampleIndicators"; // NOTE: the ID of the carousel

        protected override async Task OnInitializedAsync()
		{
			await GetCamping();
		}

		protected async Task GetCamping()
		{
			Camp = await Http.GetFromJsonAsync<Camping>("api/Camping/" + Id);
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            object[] args = { carouselName };
            await JsRuntime.InvokeVoidAsync("startCarousel", args); // NOTE: call JavaScript function with the ID of the carousel
        }
    }
}
