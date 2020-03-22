using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mamedia.Src.Domain.Core.Entities
{
    public abstract class Post
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        public bool PublishPermission { get; set; }
        public DateTime PublishDate { get; set; }
        public bool CanBePublished => CheckPublishStatus();
        [MaxLength(200)]
        public string UniqueId { get; set; }
        [MaxLength(150)]
        public string OpusName { get; set; }
        [MaxLength(150)]
        public string OpusLatinName { get; set; }
        [MaxLength(500)]
        public string CoverPhotoUrl { get; set; }
        [MaxLength(150)]
        public string CoverPhotoTag { get; set; }
        public int PostKindId { get; set; }
        public PostKind PostKind { get; set; }
        public ICollection<PostArtist> Artists { get; set; }
        public ICollection<Link> Links { get; set; }
        public int AuthorId { get; set; }
        public Admin Author { get; set; }
       
        private bool CheckPublishStatus()
        {
            if (PublishDate == null)
            {
                return false;
            }
            else
            {
                return PublishPermission && (DateTime.Now >= PublishDate);
            }
        }
    }
}
