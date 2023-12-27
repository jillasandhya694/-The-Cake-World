using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class CartModel
    {
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Measurements { get; set; }
        public Decimal Price { get; set; }
        public int Status { get; set; }
        public int Volume { get; set; }
        public int CardId { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public Decimal TotalPrice { get; set; }
        public string ProductDescription { get; set; }

    }
}