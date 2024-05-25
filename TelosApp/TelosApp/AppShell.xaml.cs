using TelosApp.Views;

namespace TelosApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ProductDetails", typeof(ProductDetails));
        }
    }
}
