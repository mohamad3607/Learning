﻿using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.ArtistModel
{
    public class CreateViewModel
    {
        
        [Display(Name = "شناسه هنرمند")]
        
        public int Id { get; set; }

        [Display(Name = "نام هنرمند")]
        
        public string Name { get; set; }
        [Display(Name = "نام لایتن هنرمند")]
        public string EnglishName { get; set; }

        [Display(Name = "بیوگرافی هنرمند")]
        public string Biography { get; set; }

        [Display(Name="حرفه های هنرمند")]
        public IEnumerable<int> Types { get; set; }
        [Display(Name = "MetaDescription")]
        public string MetaDescription { get; set; }
    }
}
