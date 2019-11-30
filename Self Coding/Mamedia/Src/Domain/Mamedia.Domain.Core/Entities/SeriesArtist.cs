using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class SeriesArtist
    {
        public int SeriesId { get; set; }
        public Series Series { get; set; }
        public int ArtistTypeId { get; set; }
        public ArtistType ArtistType { get; set; }
    }
}
