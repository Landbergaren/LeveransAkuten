using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Driver
{
    public class DriverVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public string StreetAdress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool D { get; set; }
        public bool CE { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UploadImgVm UpImg { get; set; }
    }

    [Bind(Prefix = nameof(DriverVm.UpImg))]
    public class UploadImgVm
    {
        [Required]
        public IFormFile Img { get; set; }
    }
}
