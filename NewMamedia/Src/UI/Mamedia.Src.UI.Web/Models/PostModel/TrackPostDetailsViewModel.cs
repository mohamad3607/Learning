using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mamedia.Src.Domain.Core.Entities;

namespace Mamedia.Src.UI.Web.Models.PostModel
{
    public class TrackPostDetailsViewModel : PostDetailsViewModel
    {
        public TrackPostDetailsViewModel(Post post,TrackInfo info) : base(post)
        {
            Lyric = info.Lyric;
            Cross = info.Cross;
        }
        public string Lyric { get; set; }
        public string Cross { get; set; }
    }
}
