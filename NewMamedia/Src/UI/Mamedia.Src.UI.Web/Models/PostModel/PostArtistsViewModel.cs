using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.PostModel
{
    public class PostArtistsViewModel
    {
        public PostArtistViewModel PostArtist { get; set; }
        public List<PostArtistViewModel> PostArtists { get; set; }

        public PostArtistsViewModel(List<PostArtist> postArtists)
        {
            PostArtist = new PostArtistViewModel();
            PostArtists = new List<PostArtistViewModel>();
            foreach (PostArtist pa in postArtists)
            {
                PostArtistViewModel vm = new PostArtistViewModel()
                {
                    ArtistTypeId = pa.ArtistTypeId,
                    ShowInPost = pa.ShowInPost,
                    ArtistName = pa.ArtistType.Artist.Name,
                    Type = pa.ArtistType.Type.Type
                };
                PostArtists.Add(vm);
            }
        }
        public PostArtistsViewModel()
        {
            PostArtist = new PostArtistViewModel();
            PostArtists = new List<PostArtistViewModel>();
        }
    }

    public class PostArtistViewModel
    {
        [Display(Name ="نمایش در نوشته")]
        public bool ShowInPost { get; set; }
        public int PostId { get; set; }
        [Display(Name = "نقش هنرمند")]
        public int TypeId { get; set; }
        [Display(Name = "هنرمند")]
        public int ArtistId { get; set; }
        public int ArtistTypeId { get; set; }
        [Display(Name = "نقش هنرمند")]
        public string Type { get; set; }
        [Display(Name = "نام هنرمند")]
        public string ArtistName { get; set; }
    }
}
