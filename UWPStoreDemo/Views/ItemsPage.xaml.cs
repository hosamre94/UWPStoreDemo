using System;

using UWPStoreDemo.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPStoreDemo.Views
{
    public sealed partial class ItemsPage : Page
    {
        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on ItemsPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public ItemsPage()
        {
            InitializeComponent();
        }

        private ItemsViewModel ViewModel
        {
            get { return DataContext as ItemsViewModel; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
