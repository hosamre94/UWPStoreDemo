using System;
using System.Collections.Generic;

namespace UWPStoreDemo.Core.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }
    }
}
