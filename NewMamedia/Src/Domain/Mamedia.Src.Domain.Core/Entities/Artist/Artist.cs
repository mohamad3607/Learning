using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public string Bio { get; set; }
        [MaxLength(150)]
        public string LatinName { get; set; }
        public ICollection<ArtistType> Types { get; set; }
    }
}