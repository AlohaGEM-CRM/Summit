using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummitShopApp.Utility
{
    public class UserInfo
    {
        public String Name { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }
        public string Model { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Zip { get; set; }
    }

    public class CustomerInfo
    {
        public string Name { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }
        public string Model { get; set; }
        public DateTime Date_In { get; set; }
        public DateTime Date_Out { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Contact_Mehtod { get; set; }
    }
}
