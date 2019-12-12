using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.PostModel
{
    public class CreateViewModel
    {

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "اجازه انتشار")]
        public bool AllowToPublish { get; set; }

        [Display(Name = "تاریخ انتشار")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "آدرس یکتا")]
        public string UniqueId { get; set; }

        [Display(Name = "نوع نوشته")]
        public int PostKind { get; set; }

        [Display(Name = "هنرمندان")]
        public IEnumerable<int> ArtistTypes { get; set; }
        [Display(Name = "لینک")]
        public string Link { get; set; }
        [Display(Name = "آدرس کاور")]
        public string CoverPhotoAddress { get; set; }

        [Display(Name = "تگ کاور")]
        public string CoverPhotoAlterText { get; set; }

        [Display(Name = "نام اثر")]
        public string Name { get; set; }

        [Display(Name = "نام لاتین اثر")]
        public string EnglishName { get; set; }
    }
}
