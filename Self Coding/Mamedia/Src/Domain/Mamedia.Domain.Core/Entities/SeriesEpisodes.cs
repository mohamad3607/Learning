using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public abstract class SeriesEpisode:Video
    {
        Series Series { get; set; }

    }
}
