using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
   public class PurchaseAlbumLink:PurchaseLink
    {
        public int AlbumId { get; set; }
        public PurchasableAlbum Album { get; set; }
    }
}
