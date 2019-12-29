using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.PostModel
{
    public class PAlbumCreateViewModel:CreateViewModel
    {
        [Display(Name = "قیمت آلبوم")]
        public int Price { get; set; }

        [Display(Name = "خلاصه آلبوم")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
    }
}
