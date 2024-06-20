using Microsoft.AspNetCore.Components;
using DAL.Models;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using BlazorBootstrap;

namespace CampingWebAssembly.Pages
{
	public partial class Details
	{
		[Parameter]
		public string? Id { get; set; }
		public Camping? Camp { get; set; }
		public List<Comment> Comments { get; set; } = new();

		public class CommentView
		{
			public string UserName { get; set; } = string.Empty;
			public int Rating { get; set; }
			public string Content { get; set; } = string.Empty;
		}
		public List<CommentView> DisplayComments { get; set; } = new();

		public string OwnerMail { get; set; } = string.Empty;

        const string carouselName = "carouselExampleIndicators"; // NOTE: the ID of the carousel

        private Modal requestModal = default!;

		public DateTime requested_start { get; set; } = DateTime.Now;
		public DateTime requested_end { get; set; } = DateTime.Now;

		public User? loggedUser { get; set; }

		public bool IsntLogged { get; set; } = true;

        protected override async Task OnInitializedAsync()
		{
			await GetCamping();
			
			loggedUser = AuthService.GetLoggedUser();
			IsntLogged = loggedUser == null;
		}

		protected async Task GetCamping()
		{
			Camp = await Http.GetFromJsonAsync<Camping>("api/Camping/" + Id);
			if(Camp != null)
			{
                var owner = await Http.GetFromJsonAsync<User>("api/User/" + Camp.ResponsibleId);
				OwnerMail = owner!.Mail;
                await GetComments();
            }			
		}

		protected async Task GetComments()
		{
			Comments = await Http.GetFromJsonAsync<List<Comment>>("api/Comment/" + Camp.Id);
            foreach (var comment in Comments)
            {
                DisplayComments.Add(new CommentView
                {
                    UserName = await GetUserName(comment.UserId),
                    Rating = comment.Ratings,
                    Content = comment.Content ?? ""
                });
            }
        }

		protected async Task<string> GetUserName(string userId)
		{
			var user = await Http.GetFromJsonAsync<User>("api/User/" + userId);
			if (user != null)
			{
				return user.Name;
			}
			else return "";
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            object[] args = { carouselName };
            await JsRuntime.InvokeVoidAsync("startCarousel", args); // NOTE: call JavaScript function with the ID of the carousel
        }

		protected async Task Request()
		{
			try
			{
				Request request = new Request()
				{
					UserId = loggedUser!.Id,
					ResponsibleId = Camp!.ResponsibleId,
					CampingId = Camp!.Id,
					Start = requested_start,
					End = requested_end					
				};

				await Http.PostAsJsonAsync("api/Request", request);
				await requestModal.HideAsync();
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

/*
 * using (MailMessage mail=new MailMessage())
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
*/
