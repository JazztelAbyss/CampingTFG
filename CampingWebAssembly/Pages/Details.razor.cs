using Microsoft.AspNetCore.Components;
using DAL.Models;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using BlazorBootstrap;
using System.Net.Mail;

namespace CampingWebAssembly.Pages
{
	public partial class Details
	{
		[Parameter]
		public string? Id { get; set; }
		public Camping? Camp { get; set; }
        const string carouselName = "carouselExampleIndicators"; // NOTE: the ID of the carousel

        private Modal requestModal = default!;

		public DateTime? requested_start { get; set; }
        public DateTime? requested_end { get; set; }

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

		protected void Request()
		{
			try
			{
				using (MailMessage mail=new MailMessage())
				{
					mail.From = new MailAddress("maicolapimaps@gmail.com");
					mail.To.Add("misape575@gmail.com");
					mail.Subject = "Reserva campamento";
					mail.Body = "Usted e gei";

					using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
					{
						smtp.Credentials = new System.Net.NetworkCredential("maicolapimaps@gmail.com", "");
						smtp.EnableSsl = true;
						smtp.Send(mail);
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

        private async Task OnShowModalClick()
        {
            await requestModal.ShowAsync();
        }
    }
}
