using BlazorBootstrap;
using DAL.Models;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
    public partial class Index
    {
        private string[] credentials { get; set; } = new string[2];

        private string warningText = "";

        private Modal loginModal = default!;

        private async Task OnShowModalClick()
        {
            await loginModal.ShowAsync();
        }

        private async Task Login()
        {
            try
            {
                User? user = await http.GetFromJsonAsync<User>("api/User/" + credentials[0]);
                if (user != null && user.Password.Equals(credentials[1]))
                {
                    LoggedUser = user;
                    NavigationManager.Refresh();
                }
            }
            catch
            {
                warningText = "Nombre de usuario o contraseña incorrectos";
            }
        }
    }
}
