using System.Collections.Generic;

namespace Mamedia.Domain.Core.Entities
{
    public enum TypesOfArtist
    {
        Actor=1,
        Director=1
    }

    public class TypeOfArtist
    {

        private readonly int _type;
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<ArtistType> ArtistTypes { get; set; }

    }
}
