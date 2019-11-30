using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class PurchasableAlbumArtists
    {
        public int AlbumId { get; set; }
        public PurchasableAlbum PurchasableAlbum { get; set; }
        public int ArtistTypeId { get; set; }
        public ArtistType ArtistType { get; set; }
    }
}
