using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.PostModel
{
    public class PostDetailsViewModel
    {
        DateTime _publishDate;
        public string Title { get; set; }
        public PostKind PostKind { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Link> Links { get; set; }
        public string PersianDateTime { get { return CreatePersianDate(); } }
        public string CoverPhotoUrl { get; set; }
        public string CoverPhotoTag { get; set; }
        public string OpusLatinName { get; set; }
        public string UniqueId { get; set; }
        public string LikeCount { get; set; }
        public string OpusName { get; set; }
        public string MetaDescription { get; set; }
        public List<ArtistType> ArtistTypes { get; set; }
        public IEnumerable<IGrouping<TypeOfArtist, ArtistType>> Types { get { return GetTypesFromArtistTypes(); } }

        private IEnumerable<IGrouping<TypeOfArtist,ArtistType>> GetTypesFromArtistTypes()
        {
            var groupRes = ArtistTypes.GroupBy(at => at.Type);
            return groupRes;
        }

        public PostDetailsViewModel(Post post)
        {
            Artists = new List<Artist>();
            ArtistTypes = new List<ArtistType>();
            Links = new List<Link>();
            Title = post.Title;
            _publishDate = post.PublishDate;
            UniqueId = post.UniqueId;
            PostKind = post.PostKind;
            OpusLatinName = post.OpusLatinName;
            OpusName = post.OpusName;
            CoverPhotoTag = post.CoverPhotoTag;
            CoverPhotoUrl = post.CoverPhotoUrl;
            MetaDescription = post.MetaDescription;
            foreach (PostArtist artist in post.Artists)
            {
                ArtistTypes.Add(artist.ArtistType);
                if (artist.ShowInPost)
                {
                    Artist newArtist = artist.ArtistType.Artist;
                    Artists.Add(newArtist);
                }

            }
            Links = post.Links.ToList();

        }


        private string CreatePersianDate()
        {
            MD.PersianDateTime.PersianDateTime date = new MD.PersianDateTime.PersianDateTime(_publishDate);
            return date.ToLongDateString();
        }
    }
}
