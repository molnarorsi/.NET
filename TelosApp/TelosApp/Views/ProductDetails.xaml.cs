using System.ComponentModel;
using TelosApp.Models;

namespace TelosApp.Views;

[QueryProperty(nameof(Product), "product")]
public partial class ProductDetails : ContentPage, IQueryAttributable, INotifyPropertyChanged
{
    public Product product { get; private set; }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        product = query["product"] as Product;
        OnPropertyChanged("product");
    }
    public ProductDetails()
    {
        InitializeComponent();
        BindingContext = this;
    }
}