using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class PurchaseSeriesEpisodeLink:PurchaseLink
    {
        public int PurchasableSeriesEpisodeId { get; set; }
        public PurchasableSeriesEpisode PurchasableSeriesEpisode { get; set; }
    }
}
