using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.UI.Models.PurchasableAlbumModel
{
    public class CreateViewModel
    {
       

        [Display(Name = "خلاصه آلبوم")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }

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
