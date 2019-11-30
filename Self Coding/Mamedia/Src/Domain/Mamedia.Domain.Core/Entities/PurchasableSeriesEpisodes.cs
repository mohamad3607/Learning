using Mamedia.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class PurchasableSeriesEpisode : SeriesEpisode,IPostable
    {
        public List<PurchaseSeriesEpisodeLink> PurchaseLinks { get; set; }
        public string Summary { get; set; }
        public string CoverPhotoAddress { get; set ; }
        public string CoverPhotoAlterText { get ; set ; }
    }
}
