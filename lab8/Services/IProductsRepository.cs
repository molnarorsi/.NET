using lab8.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8.Services
{
	public interface IProductsRepository
	{
		Task<ObservableCollection<Product>> LoadProducts();
	}
}
