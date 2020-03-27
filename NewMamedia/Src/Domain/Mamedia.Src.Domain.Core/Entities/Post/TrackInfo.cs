using System.ComponentModel.DataAnnotations;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class TrackInfo
    {
        public int PostId { get; set; }
        public TrackPost Post { get; set; }
        [MaxLength(500)]
        public string Cross { get; set; }
        [MaxLength(3000)]
        public string Lyric { get; set; }
    }
}