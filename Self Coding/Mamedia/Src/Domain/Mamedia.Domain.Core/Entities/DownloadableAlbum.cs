using Mamedia.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class DownloadableAlbum : Album
    {
        public ICollection<AlbumDownloadLink> DownloadLinks { get ; set ; }
        public string CoverPhotoAddress { get ; set ; }
        public string CoverPhotoAlterText { get ; set ; }
        public ICollection<DownloadableAlbumArtist> Artists { get; set; }
    }
}
