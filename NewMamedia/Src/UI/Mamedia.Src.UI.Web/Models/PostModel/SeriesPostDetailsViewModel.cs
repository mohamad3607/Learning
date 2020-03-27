using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mamedia.Src.Domain.Core.Entities;

namespace Mamedia.Src.UI.Web.Models.PostModel
{
    public class SeriesPostDetailsViewModel : PostDetailsViewModel
    {
        public SeriesPostDetailsViewModel(Post post,SeriesInfo info) : base(post)
        {
            Summary = info.Summary;
            Price = string.Format("{0:#,###} تومان", info.Price);
            Duration = $"{info.Duration} دقیقه";
            ProductionYear = info.ProductionYear.ToString();
        }
        public string Summary { get; set; }
        public string Price { get; set; }
        public string Duration { get; set; }
        public string ProductionYear { get; set; }
    }
}
