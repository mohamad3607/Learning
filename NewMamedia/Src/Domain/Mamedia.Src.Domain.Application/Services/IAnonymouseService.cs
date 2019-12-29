using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Application.Services
{
    public interface IAnonymouseService
    {
        IEnumerable<Post> GetPublishablePosts();
        Post GetPostByUniqueId(string uniqueId);
        IEnumerable<PostKind> GetAllPostKinds();
        IEnumerable<Post> GetPublishablePostsByKind(string kind);
        IEnumerable<Post> GetPublishableTracks();
        IEnumerable<Post> GetPublishableAlbums();
        TrackInfo GetTrackInfoByPostId(int postId);
        PurchasableAlbumInfo GetPAlbumInfoByPostId(int postId);
        IEnumerable<Post> SearchPost(string search);
    }
}
