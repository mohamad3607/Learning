using Mamedia.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class PurchasableAlbum : Album,IPostable
    {
        public ICollection<PurchaseAlbumLink> PurchaseLinks { get; set; }
        public string CoverPhotoAddress { get; set; }
        public string CoverPhotoAlterText { get; set; }
        public ICollection<PurchasableAlbumArtists> Artists { get; set; }
    }
}
