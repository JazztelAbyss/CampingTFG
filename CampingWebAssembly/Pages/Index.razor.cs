using BlazorBootstrap;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Json;

namespace CampingWebAssembly.Pages
{
    public partial class Index
    {
        private string[] credentials { get; set; } = new string[2];

        private Modal loginModal = default!;

        private async Task OnShowModalClick()
        {
            await loginModal.ShowAsync();
        }

        private async Task Login()
        {
        }
    }
}
