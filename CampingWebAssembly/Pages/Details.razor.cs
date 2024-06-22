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
		public List<Comment> Comments { get; set; } = new();
		public List<TagHolder> Tags { get; set; } = new();
		public List<Service> Services { get; set; } = new();
		public List<ImageCamping> Images {  get; set; } = new();

		public Comment UserComment { get; set; } = new();

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
        private Modal commentModal = default!;
        private Modal mailModal = default!;

		private string MailContent {  get; set; } = string.Empty;

        public DateTime requested_start { get; set; } = DateTime.Now;
		public DateTime requested_end { get; set; } = DateTime.Now;

		public User? loggedUser { get; set; }

		public bool IsntLogged { get; set; } = true;

        protected override async Task OnInitializedAsync()
		{
			await GetCamping();
			
			loggedUser = AuthService.GetLoggedUser();
			if(loggedUser != null)
			{
				UserComment.UserId = loggedUser.Id;
			}

			IsntLogged = loggedUser == null;
			await GetTagHolders();
		}

		protected async Task GetCamping()
		{
			Camp = await Http.GetFromJsonAsync<Camping>("api/Camping/" + Id);
			if(Camp != null)
			{
                var owner = await Http.GetFromJsonAsync<User>("api/User/" + Camp.ResponsibleId);
				OwnerMail = owner!.Mail;
				UserComment.CampingId = Camp.Id;
                await GetComments();
				await GetImages();
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

		protected async Task GetImages()
		{
			Images = await Http.GetFromJsonAsync<List<ImageCamping>>("api/ImageCamping/" + Camp!.Id);
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

		protected async Task WriteComment()
		{
			try
			{
				await Http.PostAsJsonAsync("api/Comment", UserComment);
			}
			catch
			{
				throw;
			}
		}

		private async Task WriteMail()
		{
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("maicolapimaps@gmail.com");
                mail.To.Add("misape575@gmail.com");
                mail.Subject = "Reserva campamento";
                mail.Body = MailContent;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("maicolapimaps@gmail.com", "");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        private async Task OnShowRequestClick()
        {
            await requestModal.ShowAsync();
        }
		private async Task OnShowCommentClick()
        {
            await commentModal.ShowAsync();
        }

		private async Task OnShowMailClick()
		{
			await mailModal.ShowAsync();
		}

		private async Task GetTagHolders()
		{
			Tags = await Http.GetFromJsonAsync<List<TagHolder>>("api/TagHolder/" + Camp.Id);
			if( Tags != null)
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
		}
    }
}
