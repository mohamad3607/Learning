using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class ArtistType
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int TypeId { get; set; }
        public TypeOfArtist TypeOfArtist { get; set; }
        public ICollection<MovieArtists> MovieArtists { get; set; }
        public ICollection<TrackArtist> TrackArtists { get; set; }
        public ICollection<DownloadableAlbumArtist> DownloadableAlbumArtists { get; set; }
        public ICollection<PurchasableAlbumArtists> PurchasableAlbumArtists { get; set; }
        public ICollection<SeriesArtist> SeriesArtists { get; set; }
    }
}
