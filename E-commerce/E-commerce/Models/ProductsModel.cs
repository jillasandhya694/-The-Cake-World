using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class ProductsModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public string Measurements { get; set; }
        public Decimal Price { get; set; }
        public int PPListId { get; set; }

    }  
}