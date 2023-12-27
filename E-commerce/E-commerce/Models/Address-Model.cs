using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class Address_Model
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        public Int64 Pincode { get; set; }
        public int UserId { get; set; }
        public bool IsDefault { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
    }
}