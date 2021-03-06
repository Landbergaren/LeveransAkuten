﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Company
{
    public class CompanyVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public string StreetAdress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public UploadComImgVm UpImg { get; set; }
    }

    [Bind(Prefix = nameof(CompanyVm.UpImg))]
    public class UploadComImgVm
    {
        public IFormFile Img { get; set; }
    }
}
