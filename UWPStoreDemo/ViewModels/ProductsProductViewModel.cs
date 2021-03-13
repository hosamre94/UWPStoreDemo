using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPStoreDemo.Core.Models;

namespace UWPStoreDemo.ViewModels
{
    public class ProductsProductViewModel : Screen
    {
        public ProductsProductViewModel(Product product)
        {
            Product = product;
        }


        public Product Product { get; }
    }
}
