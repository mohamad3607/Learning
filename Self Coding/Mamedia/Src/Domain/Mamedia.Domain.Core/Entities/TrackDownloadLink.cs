using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class TrackDownloadLink:DownloadLink
    {
        public int TrackId { get; set; }
        public Track Track { get; set; }
    }
}
