namespace lab8.Views;

public partial class ProductList : ContentPage
{
	public ProductList()
	{
		InitializeComponent();
		BindingContext = new Models.AllProducts();
	}
}