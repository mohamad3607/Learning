using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class ArtistType
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int TypeId { get; set; }
        public TypeOfArtist Type { get; set; }
        public ICollection<PostArtist> Posts { get; set; }
    }
}
