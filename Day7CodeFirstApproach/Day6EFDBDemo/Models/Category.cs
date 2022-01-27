using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Day6EFDBDemo.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }
}