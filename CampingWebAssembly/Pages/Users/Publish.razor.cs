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
        private async Task CreateCamping()
        {
            try
            {
                camping.Portrait = images.First();
                camping.ResponsibleId = AuthService.GetLoggedUser().Id;
                images.RemoveAt(0);
                await UploadImages(images);
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
