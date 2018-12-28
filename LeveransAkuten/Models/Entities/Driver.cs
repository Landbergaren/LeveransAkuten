using System;
using System.Collections.Generic;

namespace LeveransAkuten.Models.Entities
{
    public partial class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public string StreetAdress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string AccountId { get; set; }
        public string Description { get; set; }
        public bool? A { get; set; }
        public bool? B { get; set; }
        public bool? C { get; set; }
        public bool? D { get; set; }
        public bool? Ce { get; set; }

   
    }
}
