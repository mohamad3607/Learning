using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mamedia.Src.UI.Web.Models.PostModel
{
    public class DefaultPagePostsViewModel
    {
        private DateTime _publishDate;
        public DefaultPagePostsViewModel(Post post)
        {
            Artists = new List<Artist>();
            Title = post.Title;
            _publishDate = post.PublishDate;
            UniqueId = post.UniqueId;
            PostKind = post.PostKind;
            OpusLatinName = post.OpusLatinName;
            OpusName = post.OpusName;
            CoverPhotoTag = post.CoverPhotoTag;
            CoverPhotoUrl = post.CoverPhotoUrl;
            foreach(PostArtist artist in post.Artists)
            {
                Artist newArtist = artist.ArtistType.Artist;
                Artists.Add(newArtist);
            }
            Links = post.Links;
        }

        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "آدرس یکتا")]
        public string UniqueId { get; set; }

        [Display(Name = "نوع نوشته")]
        public PostKind PostKind { get; set; }

        [Display(Name = "تاریخ شمسی")]
        public string PersianPubDate { get { return GetPersianDate(); } }
        public string OpusName { get; set; }
        public string OpusLatinName { get; set; }
        public string CoverPhotoUrl { get; set; }
        public string CoverPhotoTag { get; set; }
        public List<Artist> Artists { get; set; }
        public ICollection<Link> Links { get; set; }

        private string GetPersianDate()
        {
            var dte = new MD.PersianDateTime.PersianDateTime(_publishDate);
            return dte.ToShortDateString();
        }
    }
}
