using System;
using System.Collections.Generic;
using System.Text;

namespace UWPStoreDemo.Core.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public string Category { get; set; }
        public int Total { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public string Image { get; set; }

        public string SubTitle => $"{Price}$/{Unit}";
    }
}
