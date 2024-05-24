using DAL.Models;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages.Users
{
    public partial class Register
    {
        //Usuario a crear y repetir contraseña
        private User user { get; set; } = new();
        private string pswrd = "";
        private async Task CreateAccount()
        {
            if(user.Password.Equals(pswrd))
            {
                try
                {
                    await Http.PostAsJsonAsync("api/User", user);
                }
                catch
                {

                }
            }
        }
    }
}
