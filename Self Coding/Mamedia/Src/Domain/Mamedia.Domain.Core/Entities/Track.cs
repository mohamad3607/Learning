using Mamedia.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class Track : Audio
    {

        public string Cross { get; set; }
        public string Lyric { get; set; }
        public ICollection<TrackDownloadLink> DownloadLinks { get; set; }
        public string CoverPhotoAddress { get; set; }
        public string CoverPhotoAlterText { get; set; }
        public ICollection<TrackArtist> TrackArtists { get; set; }
    }
}
