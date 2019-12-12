using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class PostArtist
    {
        public int ArtistId { get; set; }
        public int TypeId { get; set; }
        public ArtistType ArtistType { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public bool IsMain { get; set; }
    }
}
