namespace CampingWebAssembly.Pages
{
    public partial class CampList
    {
        public bool showSearchMenu = false;

        public double priceValue = 0.00;

        private void showSearch()
        {
            showSearchMenu = !showSearchMenu;
        }
    }
}
