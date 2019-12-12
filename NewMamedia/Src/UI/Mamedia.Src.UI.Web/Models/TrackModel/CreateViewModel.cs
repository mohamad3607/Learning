using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.TrackModel
{
    public class CreateViewModel
    {
        [Display(Name="کراس آهنگ")]
        [DataType(DataType.MultilineText)]
        public string Cross { get; set; }

        [Display(Name = "متن آهنگ")]
        [DataType(DataType.MultilineText)]
        public string Lyric { get; set; }

        [Display(Name = "لینک دانلود")]
        public string DownloadLinks { get; set; }

        [Display(Name = "آدرس کاور")]
        public string CoverPhotoAddress { get; set; }

        [Display(Name = "تگ کاور")]
        public string CoverPhotoAlterText { get; set; }

        [Display(Name = "هنرمندان")]
        public IEnumerable<int> ArtistTypes { get; set; }

        [Display(Name = "نام اثر")]
        public string Name { get; set; }

        [Display(Name = "نام لاتین اثر")]
        public string EnglishName { get; set; }
    }
}
