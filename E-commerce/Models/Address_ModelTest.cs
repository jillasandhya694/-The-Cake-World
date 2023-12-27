using System;

namespace Models
{
    public class Address_ModelTest
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        public Int64 Pincode { get; set; }
        public int UserId { get; set; }
        public bool IsDefault { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
    }

    public class common {

        public int UserId2 { get; set; }
        private int UserId3 { get; set; }
        protected int UserId4 { get; set; }
        protected internal int UserId5 { get; set; }
    }
}
