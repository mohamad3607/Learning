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
        [MaxLength(200)]
        public string Image { get; set; }
        [MaxLength(200)]
        public string MetaDescription { get; set; }
        public ICollection<ArtistType> Types { get; set; }
    }
}