using Mamedia.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class Movie : Video,IPostable
    {
        public ICollection<MovieLink> PurchaseLinks { get; set; }
        public int ArtistTypeId { get; set; }
        public ICollection<MovieArtists> Artists { get; set; }
        public string Summary { get; set; }
        public string CoverPhotoAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CoverPhotoAlterText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
