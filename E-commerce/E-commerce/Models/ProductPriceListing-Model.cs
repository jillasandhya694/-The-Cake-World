using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class ProductPriceListing_Model
    {
        public int PPListId { get; set;}
        public int ProductId { get; set;}
        public int Quantity { get; set;}
        public string Measurements { get; set;}
        public Decimal Price { get; set;}
        public int UserId { get; set; }
        public int Status { get; set; }
       
    }
}
