using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Caliburn.Micro;

using UWPStoreDemo.Core.Models;
using UWPStoreDemo.Core.Services;
using UWPStoreDemo.Helpers;
using UWPStoreDemo.Views;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPStoreDemo.ViewModels
{
    public class ProductsViewModel : Conductor<ProductsProductViewModel>.Collection.OneActive
    {
        private readonly INavigationService _navigationService;

        public ProductsViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public void EditProductClicked() => _navigationService.NavigateToViewModel<EditProductViewModel>(ActiveItem.Product);

        public void NewProductCliked() => _navigationService.NavigateToViewModel<EditProductViewModel>();


        public async Task DeleteAsync()
        {
            // Simulate api call
            var successd = await SampleDataService.DeleteProductAsync(ActiveItem.Product.Id);

            if (successd)
                Items.Remove(ActiveItem);
        }


        public async Task LoadDataAsync()
        {
            Items.Clear();
            var data = await SampleDataService.GetGridDataAsync();
            Items.AddRange(data.Select(x => new ProductsProductViewModel(x)));
        }
    }
}
