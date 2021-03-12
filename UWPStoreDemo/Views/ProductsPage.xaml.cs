using System;

using UWPStoreDemo.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPStoreDemo.Views
{
    public sealed partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
        }

        private ProductsViewModel ViewModel
        {
            get { return DataContext as ProductsViewModel; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
