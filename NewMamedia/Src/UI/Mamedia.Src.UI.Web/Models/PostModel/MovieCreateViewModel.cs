using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.PostModel
{
    public class MovieCreateViewModel:CreateViewModel
    {
        [Display(Name = "قیمت فیلم")]
        public int Price { get; set; }

        [Display(Name = "خلاصه فیلم")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
        [Display(Name = "مدت زمان( دقیقه)")]
        public int Duration { get; set; }
        [Display(Name = "سال تولید")]
        public int ProductionYear { get; set; }

    }
}
