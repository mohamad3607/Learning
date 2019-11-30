using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.UI.Models.ArtistModel
{
    public class AllViewModel
    {
        public AllViewModel(Artist artist)
        {
            Id = artist.Id;
            Name = artist.Name;
        }
        [Display(Name = "شناسه هنرمند")]
        public int Id { get; set; }
        [Display(Name="نام هنرمند")]
        public string Name { get; set; }
    }
}
