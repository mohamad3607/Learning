using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class SeriesPost:Post
    {
        public SeriesInfo Info { get; set; }
    }

    public class SeriesInfo
    {
        public int PostId { get; set; }
        public SeriesPost Post { get; set; }
        [MaxLength(1000)]
        public string Summary { get; set; }
        public int Price { get; set; }
        public int ProductionYear { get; set; }
        public int Duration { get; set; }
    }
}
