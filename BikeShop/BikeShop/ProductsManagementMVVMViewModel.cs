using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop
{
    public class ProductsManagementMVVMViewModel : Notifier
    {
        #region Properties

        private string? searchInput;
        public string? SearchInput
        {
            get => searchInput;
            set
            {
                searchInput = value;
                OnPropertyChanged(nameof(SearchInput));
                OnSearchInputChanged();
            }
        }

        private IEnumerable<Product>? products;
        public IEnumerable<Product>? Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private Product? selectedItem;
        public Product? SelectedItem
        {
            get => selectedItem;
            set {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        #endregion

        private ProductsFactory factory = new ProductsFactory();

        public ProductsManagementMVVMViewModel() => Products = Enumerable.Empty<Product>();

        private void OnSearchInputChanged()
        {
            SelectedItem = null;
            Products = factory.FindProducts(SearchInput);
        }

    }
}
