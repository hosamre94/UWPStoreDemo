using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UWPStoreDemo.Core.Enum;
using UWPStoreDemo.Core.Models;

namespace UWPStoreDemo.Core.Services
{

    public static class SampleDataService
    {
        private static List<Product> _products;
        private static List<Order> _orders;

        static SampleDataService()
        {
            try
            {
                _products = SeedProducts();
                _orders = SeedOrders();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private static IEnumerable<Order> AllOrders() => _orders;

        #region Products
        private static IEnumerable<Product> AllProducts() => _products;

        public static async Task AddProductAsync(Product product)
        {
            await Task.Delay(3000);

            //do some validation befor adding the product
            _products.Add(product);
        }

        public static async Task<bool> UpdateProductAsync(Product product)
        {
            await Task.Delay(3000);
            var currentProduct = _products.FirstOrDefault(x => x.Id == product.Id);
            if (currentProduct == null)
                return false;

            currentProduct.Title = product.Title;
            currentProduct.Barcode = product.Barcode;
            currentProduct.Category = product.Category;
            currentProduct.Description = product.Description;
            currentProduct.Price = product.Price;
            currentProduct.Total = product.Total;
            currentProduct.Unit = product.Unit;
            currentProduct.Image = product.Image;

            return true;
        }

        public static async Task<bool> DeleteProductAsync(string id)
        {
            await Task.Delay(1000);

            //Get the local instance of the list 
            var products = _products;
            var productIndex = products.FindIndex(x => x.Id == id);


            if (productIndex < 0)
                return false;

            products.RemoveAt(productIndex);
            return true;
        }

        public static async Task<IEnumerable<Product>> GetGridDataAsync()
        {
            await Task.CompletedTask;
            return AllProducts();
        }
        #endregion


        #region Helper
        private static List<Order> SeedOrders()
        {
            var fakeOrders = new Faker<Order>()
                .StrictMode(true)
                .RuleFor(o => o.Id, f => f.Random.Guid().ToString())
                .RuleFor(o => o.ProductName, f => f.Commerce.ProductName())
                .RuleFor(o => o.Quantity, f => f.Random.Number(1, 3))
                .RuleFor(o => o.OrderDate, f => f.Date.Recent())
                .RuleFor(o => o.Status, f => f.Random.Enum<OrderStatus>().ToString());

            return fakeOrders.Generate(100);
        }

        private static List<Product> SeedProducts()
        {
            var units = new[] { "Piece", "kg", "Liter" };
            var categories = new[] { "pice", "kg", "liter" };
            var fakeProducts = new Faker<Product>()
                .RuleFor(o => o.Id, f => f.Random.Guid().ToString())
                .RuleFor(o => o.Title, f => f.Commerce.ProductName())
                .RuleFor(o => o.Price, f => f.Random.Number(5, 15))
                .RuleFor(o => o.Unit, f => f.Random.ListItem(units))
                .RuleFor(o => o.Category, f => f.Commerce.Categories(1).FirstOrDefault())
                .RuleFor(o => o.Description, f => f.Commerce.ProductDescription())
                .RuleFor(o => o.Total, f => f.Random.Number(100, 1000))
                .RuleFor(o => o.Image, f => $"/Assets/Images/{f.Random.Number(1, 10)}.png");

            return fakeProducts.Generate(40);
        }
        #endregion
    }
}
