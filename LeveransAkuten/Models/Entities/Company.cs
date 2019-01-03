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

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string AspNetUsersId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
    }
}
