using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPStoreDemo.Core.Models;
using UWPStoreDemo.Core.Services;

namespace UWPStoreDemo.ViewModels
{
    public class EditProductViewModel : Screen
    {
        private readonly INavigationService _navigationService;

        private string _id;
        private string _title;
        private double _price;
        private string _unit;
        private string _category;
        private int _total;
        private string _description;
        private string _barcode;
        private string _image;
        private bool _loading;

        public EditProductViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
                NotifyOfPropertyChange(() => CanSave);
            }
        }



        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
                NotifyOfPropertyChange(() => CanSave);

            }
        }
        public string Unit
        {
            get => _unit; set
            {
                _unit = value;
                NotifyOfPropertyChange(() => Unit);
                NotifyOfPropertyChange(() => CanSave);

            }
        }
        public string Category
        {
            get => _category; set
            {
                _category = value;
                NotifyOfPropertyChange(() => Category);
                NotifyOfPropertyChange(() => CanSave);

            }
        }
        public int Total
        {
            get => _total; set
            {
                _total = value;
                NotifyOfPropertyChange(() => Total);
            }
        }
        public string Description
        {
            get => _description; set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
        public string Barcode
        {
            get => _barcode; set
            {
                _barcode = value;
                NotifyOfPropertyChange(() => Barcode);
            }
        }
        public string Image
        {
            get => _image; set
            {
                _image = value;
                NotifyOfPropertyChange(() => Image);
            }
        }

        public bool CanSave =>
            !string.IsNullOrWhiteSpace(Title) &&
            !string.IsNullOrWhiteSpace(Unit) &&
            !string.IsNullOrWhiteSpace(Category) &&
             Price > 0;




        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                NotifyOfPropertyChange(() => Loading);
            }
        }

        internal void Load(Product product)
        {
            // use automapper insted
            _id = product.Id;
            Title = product.Title;
            Barcode = product.Barcode;
            Category = product.Category;
            Description = product.Description;
            Price = product.Price;
            Total = product.Total;
            Unit = product.Unit;
            Image = product.Image;
        }

        public async Task SaveAsync()
        {
            try
            {
                Loading = true;

                // use automapper insted
                var product = new Product
                {
                    Id = _id,
                    Title = Title,
                    Barcode = Barcode,
                    Category = Category,
                    Description = Description,
                    Price = Price,
                    Total = Total,
                    Unit = Unit,
                    Image = $"/Assets/Images/{new Random().Next(1, 10)}.png"
                };


                if (string.IsNullOrEmpty(_id))
                    await SampleDataService.AddProductAsync(product);
                else
                    await SampleDataService.UpdateProductAsync(product);
            }
            finally
            {
                Loading = false;
                _navigationService.NavigateToViewModel(typeof(ProductsViewModel));
            }

        }
    }
}
