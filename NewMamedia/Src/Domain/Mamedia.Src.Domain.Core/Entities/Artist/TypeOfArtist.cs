using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class TypeOfArtist
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public ICollection<ArtistType> Artists { get; set; }
    }
}
