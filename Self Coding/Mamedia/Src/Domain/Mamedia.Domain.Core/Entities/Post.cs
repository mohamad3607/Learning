using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class Post 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool AllowToPublish { get; set; }
        public DateTime PublishDate { get; set; }
        public bool CanBePublished => CheckPublishStatus();
        public string UniqueId { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public DownloadableAlbum DownloadableAlbum { get; set; }
        public Movie Movie { get; set; }
        public PurchasableAlbum PurchasableAlbum { get; set; }
        public PurchasableSeriesEpisode PurchasableSeriesEpisode { get; set; }
        public int PostKindId { get; set; }
        public PostKind PostKind { get; set; }
        private bool CheckPublishStatus()
        {
            if(PublishDate==null)
            {
                return false;
            }
            else
            {
                return AllowToPublish && (DateTime.Now >= PublishDate);
            }
        }
    }
}
