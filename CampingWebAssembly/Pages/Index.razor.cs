using BlazorBootstrap;

namespace CampingWebAssembly.Pages
{
    public partial class Index
    {
        private Modal loginModal = default!;

        private async Task OnShowModalClick()
        {
            await loginModal.ShowAsync();
        }

        private async Task OnHideModalClick()
        {
            await loginModal.HideAsync();
        }
    }
}
