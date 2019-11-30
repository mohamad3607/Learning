using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class Series:Video
    {
        public ICollection<SeriesEpisode> Episodes { get; set; }
        public ICollection<SeriesArtist> Artists { get; set; }
        //public List<Artist> Actors { get; set; }
        //public List<Artist> Directors { get; set; }
        //public List<Artist> Writers { get; set; }
        public string Summary { get; set; }
    }
}
