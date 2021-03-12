using System;

using UWPStoreDemo.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPStoreDemo.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }
    }
}
