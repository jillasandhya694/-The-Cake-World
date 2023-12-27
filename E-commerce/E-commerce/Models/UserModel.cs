using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public char Gender { get; set; }
        public Int64 PhoneNo { get; set; }
        public Int64 AdharNo { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBlocked { get; set; }
        public string Password { get; set; }
    }
}