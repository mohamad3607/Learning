using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.UI.Models.PostModel
{
    public class PostDetailsViewModel
    {
        DateTime _publishDate;
        public string Title { get; set; }
        public string Kind { get; set; }
        public string KindAddress { get; set; }
        public List<ArtistType> Artists { get; set; }
        public List<DownloadLink> DownloadLinks { get; set; }
        public string PersianDateTime { get { return CreatePersianDate(); } }
        public string CoverPhotoUrl { get; set; }
        public string CoverPhotoTag { get; set; }
        public string EnglishName { get; set; }
        public string Cross { get; set; }
        public string UniqueId { get; set; }
        public string LikeCount { get; set; }
        public string detailText { get; set; }
        private string CreatePersianDate()
        {
            MD.PersianDateTime.PersianDateTime date = new MD.PersianDateTime.PersianDateTime(_publishDate);
            return date.ToLongDateString();
        }

        public string Name { get; set; }

        public PostDetailsViewModel(Post post)
        {
            Artists = new List<ArtistType>();
            DownloadLinks = new List<DownloadLink>();
            _publishDate = post.PublishDate;
            int diff = (int)((DateTime.Now - _publishDate).TotalDays * 7 + 23);
            LikeCount = diff.ToString();
            UniqueId = post.UniqueId;
            Title = post.Title;
            detailText = post.Track.Lyric;
            if(post.PostKind.Id==1)
            {
                Kind = "آهنگ جدید";
                KindAddress = "Tracks";
                CoverPhotoTag = post.Track.CoverPhotoAlterText;
                CoverPhotoUrl = post.Track.CoverPhotoAddress;
                Name = post.Track.Name;
                Cross = post.Track.Cross;
                EnglishName = post.Track.EnglishName;
                foreach(TrackDownloadLink link in post.Track.DownloadLinks)
                {
                    DownloadLink dlink = new TrackDownloadLink();
                    dlink = link;
                    DownloadLinks.Add(dlink);
                }
                foreach(TrackArtist artist in post.Track.TrackArtists)
                {
                    ArtistType artistType = new ArtistType()
                    {
                        Artist = artist.ArtistType.Artist,
                        TypeOfArtist = artist.ArtistType.TypeOfArtist
                    };
                    Artists.Add(artistType);
                }
            }
            else
            {

            }
        }
    }
}
