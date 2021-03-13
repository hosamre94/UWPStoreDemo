using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWPStoreDemo.Core.Models;
using UWPStoreDemo.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace UWPStoreDemo.Views
{
    public partial class EditProductPage : Page
    {
        public EditProductPage()
        {
            InitializeComponent();
        }

        private EditProductViewModel ViewModel
        {
            get { return DataContext as EditProductViewModel; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
                ViewModel.Load((Product)e.Parameter);

            await Task.CompletedTask;
        }
    }
}
