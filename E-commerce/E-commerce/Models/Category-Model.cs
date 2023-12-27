using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class Category_Model
    {
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
    }
}