using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class DownloadableAlbumArtist
    {
        public int AlbumId { get; set; }
        public DownloadableAlbum DownloadableAlbum { get; set; }
        public int ArtistTypeId { get; set; }
        public ArtistType ArtistType { get; set; }
    }
}
