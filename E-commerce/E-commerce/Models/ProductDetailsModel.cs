using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class ProductDetailsModel
    {
        public ProductsModel data1 { get; set; }
        public List<ProductPriceListing_Model> data2 { get; set; }
    }
}