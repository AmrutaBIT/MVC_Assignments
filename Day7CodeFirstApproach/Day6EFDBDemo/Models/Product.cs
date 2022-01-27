using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day6EFDBDemo.Models
{
    public class Product
    {
        public long productId { get; set; }
        public string productName { get; set; } 
        public Nullable<decimal> price { get; set; }
        public Nullable<System.DateTime> dateOfPurchase { get; set; }
        public string availabilityStatus { get; set; }
        public Nullable<long> categoryId { get; set; }
        public Nullable<long> brandId { get; set; }
        public Nullable<bool> active { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }  
        
    }
}