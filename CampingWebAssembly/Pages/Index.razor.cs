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

        private void Login()
        {
            try
            {
                if (AuthService.Login(credentials[0], credentials[1]))
                {
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
