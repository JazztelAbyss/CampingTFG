using DAL.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages.Users
{
    public partial class Publish
    {
        //Usuario a crear y repetir contraseña
        private Camping camping { get; set; } = new();
        private List<byte[]> images = new List<byte[]>();
        private List<Service> services = new();
        public List<int> campServiceIds = new();

		protected override async Task OnInitializedAsync()
		{
            services = await Http.GetFromJsonAsync<List<Service>>("api/Service");
		}

		private async Task CreateCamping()
        {
            try
            {
                camping.Portrait = images.First();
                camping.ResponsibleId = AuthService.GetLoggedUser().Id;
                images.RemoveAt(0);
                await UploadImages(images);
                await UploadServices(campServiceIds);
                await Http.PostAsJsonAsync("api/Camping", camping);
                Navigation.NavigateTo("/");
            }
            catch
            {
                throw;
            }
            
        }

        private async Task UploadImages(List<byte[]> images)
        {
            foreach(var image in images)
            {
                var db_image = new ImageCamping
                {
                    CampingId = camping.Id,
                    Image = image,
                };
                await Http.PostAsJsonAsync("api/ImageCamping", db_image);
            }
        }

        private async Task UploadServices(List<int> serviceIds)
        {
            foreach (var serviceId in serviceIds)
            {
                var tagholder = new TagHolder
                {
                    CampingId = camping.Id,
                    ServiceId = serviceId,
                };
                await Http.PostAsJsonAsync("api/TagHolder", tagholder);
            }
        }


        private async Task HandleFileChange(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                var buffer = new byte[file.Size];
                using var stream = file.OpenReadStream();
                await stream.ReadAsync(buffer, 0, (int)file.Size);
                images.Add(buffer);
            }
        }
    }
}
