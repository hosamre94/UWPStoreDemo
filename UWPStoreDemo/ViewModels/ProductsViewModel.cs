using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Caliburn.Micro;

using UWPStoreDemo.Core.Models;
using UWPStoreDemo.Core.Services;
using UWPStoreDemo.Helpers;

namespace UWPStoreDemo.ViewModels
{
    public class ProductsViewModel : Screen
    {
        public ObservableCollection<Product> Source { get; } = new ObservableCollection<Product>();

        public ProductsViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();
            (await SampleDataService.GetGridDataAsync())
                .ToList()
                .ForEach(x => Source.Add(x));
        }
    }
}
