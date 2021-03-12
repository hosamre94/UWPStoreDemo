using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _products = SeedProducts();
            _orders = SeedOrders();

        }

        private static IEnumerable<Order> AllOrders() => _orders;

        private static IEnumerable<Product> AllProducts() => _products;

        public static async Task<IEnumerable<Product>> GetGridDataAsync()
        {
            await Task.CompletedTask;
            return AllProducts();
        }


        #region Helper
        private static List<Order> SeedOrders()
        {
            var fakeOrders = new Faker<Order>()
                .StrictMode(true)
                .RuleFor(o => o.Id, f => new Guid().ToString())
                .RuleFor(o => o.ProductName, f => f.Commerce.ProductName())
                .RuleFor(o => o.Quantity, f => f.Random.Number(1, 3))
                .RuleFor(o => o.OrderDate, f => f.Date.Recent())
                .RuleFor(o => o.Status, f => f.Random.Enum<OrderStatus>().ToString());

            return fakeOrders.Generate(100);
        }

        private static List<Product> SeedProducts()
        {
            var units = new[] { "pice", "kg", "liter" };
            var categories = new[] { "pice", "kg", "liter" };
            var fakeProducts = new Faker<Product>()
                .RuleFor(o => o.Id, f => new Guid().ToString())
                .RuleFor(o => o.Title, f => f.Commerce.ProductName())
                .RuleFor(o => o.Price, f => f.Random.Number(5, 15))
                .RuleFor(o => o.Unit, f => f.Random.ListItem(units))
                .RuleFor(o => o.Category, f => f.Commerce.Categories(1).FirstOrDefault())
                .RuleFor(o => o.Description, f => f.Commerce.ProductDescription())
                .RuleFor(o => o.Total, f => f.Random.Number(100, 1000))
                .RuleFor(o => o.Image, f => $"/Assets/Images/{f.Random.Number(1, 4)}.png");

            return fakeProducts.Generate(15);
        }
        #endregion
    }
}
