using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class AlbumDownloadLink:DownloadLink
    {
        public int AlbumId { get; set; }
        public DownloadableAlbum Album { get; set; }
    }
}
