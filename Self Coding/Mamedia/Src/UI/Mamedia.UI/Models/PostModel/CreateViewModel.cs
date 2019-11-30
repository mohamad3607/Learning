using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.UI.Models.PostModel
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
        [Display(Name = "انتخاب تک آهنگ")]
        public int TrackId { get; set; }
    }
}
