using System;
using System.Collections.Generic;

namespace LeveransAkuten.Models.Entities
{
    public partial class Company
    {
        public Company()
        {
            Ad = new HashSet<Ad>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string StreetAdress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Ad> Ad { get; set; }
    }
}
