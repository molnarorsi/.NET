using System.Reflection;
using TelosApp.Models;

namespace TelosApp.Views;

public partial class ProductList : ContentPage
{
	public ProductList()
	{
		InitializeComponent();
        BindingContext = new Models.AllProducts();
    }

    private async void productsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

        if (e.CurrentSelection.Count != 0)
        {
            Product product = e.CurrentSelection.FirstOrDefault() as Product;
            var navigationParams = new Dictionary<string, object>
                {
                    { "product", product }
                };
            await Shell.Current.GoToAsync("ProductDetails", navigationParams);
            productsCollection.SelectedItem = null;
        }
    }
}