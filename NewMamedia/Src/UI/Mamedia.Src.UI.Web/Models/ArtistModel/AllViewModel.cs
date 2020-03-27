using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.ArtistModel
{
    public class AllViewModel
    {
        public AllViewModel(Artist artist)
        {
            Id = artist.Id;
            Name = artist.Name;
            MetaDescription = artist.MetaDescription;
            LatinName = artist.LatinName;
        }
        [Display(Name = "شناسه هنرمند")]
        public int Id { get; set; }
        [Display(Name="نام هنرمند")]
        public string Name { get; set; }
        [Display(Name = "MetaDescription")]
        public string MetaDescription { get; set; }
        public string LatinName { get;  set; }
    }
}
