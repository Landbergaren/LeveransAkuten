using System;
using System.Collections.Generic;

namespace LeveransAkuten.Models.Entities
{
    public partial class Driver
    {
        public Driver()
        {
            Ad = new HashSet<Ad>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool Ce { get; set; }
        public bool D { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AspNetUsersId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
    }
}
