﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class TrackArtist
    {
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int ArtistTypeId { get; set; }
        public ArtistType ArtistType { get; set; }
    }
}
