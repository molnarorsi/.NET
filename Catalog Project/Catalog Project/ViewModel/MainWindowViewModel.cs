using Catalog_Project.Common.MVVM;
using Catalog_Project.Logic;
using Catalog_Project.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Project.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static CatalogController CatalogController;
        public static MainWindowViewModel Instance;
        private List<Manufacturer> manufacturerList;
        private int manufacturerId;
        private List<Model.Model> modelList;

        public List <ModelList>
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public int ManufacturerId
		{
            get { return manufacturerId; }
            set { manufacturerId = value;
                this.RaisePropertyChanged();
            }
        }


        public List <Manufacturer> ManufacturerList
        {
            get { return manufacturerList; }
            set { manufacturerList = value;
                this.RaisePropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            CatalogController = new CatalogController();
            MainWindowViewModel.Instance = this;
            GetManufacturers();
        }

        private void GetManufacturers()
        {
            ManufacturerList = MainWindowViewModel.CatalogController.GetManufacturers();
        }
    }
}
