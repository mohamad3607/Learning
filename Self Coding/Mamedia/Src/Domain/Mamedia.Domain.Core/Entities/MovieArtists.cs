using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class MovieArtists
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ArtistTypeId { get; set; }
        public ArtistType ArtistType { get; set; }
    }
}
