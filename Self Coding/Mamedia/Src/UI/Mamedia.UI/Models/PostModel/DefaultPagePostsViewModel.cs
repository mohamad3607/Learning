using Mamedia.Domain.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mamedia.UI.Models.PostModel
{
    public class DefaultPagePostsViewModel
    {
        private DateTime _publishDate;
        public DefaultPagePostsViewModel(Post post)
        {
            Title = post.Title;
            _publishDate = post.PublishDate;
            UniqueId = post.UniqueId;
            PostKind = post.PostKind;
            Track = post.Track;
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
        public Track Track { get; set; }

        private string GetPersianDate()
        {
            var dte = new MD.PersianDateTime.PersianDateTime(_publishDate);
            return dte.ToShortDateString();
        }
    }
}
