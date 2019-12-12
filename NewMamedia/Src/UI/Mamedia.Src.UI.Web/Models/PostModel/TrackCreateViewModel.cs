using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.PostModel
{
    public class TrackCreateViewModel:CreateViewModel
    {
        [Display(Name = "کراس آهنگ")]
        [DataType(DataType.MultilineText)]
        public string Cross { get; set; }

        [Display(Name = "متن آهنگ")]
        [DataType(DataType.MultilineText)]
        public string Lyric { get; set; }
    }
}
