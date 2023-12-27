using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class CartModel : CommonClass
    {
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Measurements { get; set; }
        public Decimal Price { get; set; }
        public int Status { get; set; }
        public int Volume { get; set; }
        public int CardId { get; set; }
        public string ProductName { get; set; }
        public Decimal TotalPrice { get; set; }
        public string ProductDescription { get; set; }
        public string getuserId() {
            int a = this.UserId;
            int b = this.Id;
            return a.ToString();
        }

    }

    public class CommonClass {
        protected int UserId { get; set; }
        public int UserName { get; set; }
        private int Id { get; set; }
        public string getuserId2()
        {
            int a = UserId;
            int b = Id;
            return a.ToString();
        }
    }


}