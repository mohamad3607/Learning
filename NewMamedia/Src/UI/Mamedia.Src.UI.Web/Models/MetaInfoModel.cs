using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models
{
    public class MetaInfoModel
    {
        [Display(Name ="Id")]
        public int Id { get; set; }
        [Display(Name = "Url")]
        public string Url { get; set; }
        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; }
        [Display(Name = "H1Tag")]
        public string H1Tag { get; set; }
        [Display(Name = "H2Tag")]
        public string H2Tag { get; set; }
        [Display(Name = "PageTitle")]
        public string PageTitle { get; set; }

      
    }
}
