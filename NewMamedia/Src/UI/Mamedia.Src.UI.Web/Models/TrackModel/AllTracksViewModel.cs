using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models
{
    public class AllTracksViewModel
    {
        public AllTracksViewModel(TrackPost track)
        {
            Id = track.Id;
            Name = track.OpusName;

           
        }
        [Display(Name="شناسه آهنگ")]
        public int Id { get; set; }
        [Display(Name = "نام آهنگ")]
        public string Name { get; set; }
        [Display(Name = "هنرمندان")]
        public string MainArtistName { get; set; }
    }
}
