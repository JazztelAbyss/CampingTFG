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

        private User? LoggedUser { get; set; }

        private async Task OnShowModalClick()
        {
            await loginModal.ShowAsync();
        }

        private async Task Login()
        {
            try
            {
                var user = await http.GetFromJsonAsync<User>("api/User/" + credentials[0]);
                if (user != null && user.Password == credentials[1])
                {
                    AuthService.Login(user);
                    LoggedUser = user;
                    await loginModal.HideAsync();
                    NavigationManager.NavigateTo("/campings");
                }
                else throw new Exception();
            }
            catch
            {
                warningText = "Nombre de usuario o contraseña incorrectos";
            }
        }
    }
}
