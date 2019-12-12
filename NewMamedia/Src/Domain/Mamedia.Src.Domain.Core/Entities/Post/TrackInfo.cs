using System.ComponentModel.DataAnnotations;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class TrackInfo
    {
        public int PostId { get; set; }
        public TrackPost Post { get; set; }
        [MaxLength(500)]
        public string Cross { get; set; }
        public string Lyric { get; set; }
    }
}