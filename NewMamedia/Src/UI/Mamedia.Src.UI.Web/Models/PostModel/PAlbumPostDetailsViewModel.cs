using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mamedia.Src.Domain.Core.Entities;

namespace Mamedia.Src.UI.Web.Models.PostModel
{
    public class PAlbumPostDetailsViewModel : PostDetailsViewModel
    {
        public PAlbumPostDetailsViewModel(Post post,PurchasableAlbumInfo info) : base(post)
        {
            Summary = info.Summary;
            Price = string.Format("{0:#,###} تومان", info.Price);
        }
        public string Summary { get; set; }
        public string Price { get; set; }
    }
}
