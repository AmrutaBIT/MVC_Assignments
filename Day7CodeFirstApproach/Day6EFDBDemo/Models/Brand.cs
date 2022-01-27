using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Day6EFDBDemo.Models
{
    public class Brand
    {
        [Key]
        public long brandId { get; set; }
        public string brandName { get; set;}
    }
}