using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.Entities
{
    public class BudAkutenUsers : IdentityUser
    {
        [StringLength(250)]
        public string ImageUrl { get; set; }
        [StringLength(100)]
        public string StreetAdress { get; set; }
        [StringLength(20)]
        public string ZipCode { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
    }
}
