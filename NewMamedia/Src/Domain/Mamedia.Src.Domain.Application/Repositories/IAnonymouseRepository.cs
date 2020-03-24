using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Application.Repositories
{
    public interface IAnonymouseRepository
    {
        IEnumerable<Post> GetPublishablePosts();
        Post GetPostByUniqueId(string uniqueId);
        IEnumerable<PostKind> GetAllPostKinds();
        TrackInfo GetTrackInfoByPostId(int postId);
        PurchasableAlbumInfo GetPAlbumInfoByPostId(int postId);
        IEnumerable<Post> GetPublishablePostsByKind(string kind);
        IEnumerable<Post> GetPublishableTracks();
        IEnumerable<Post> GetPublishableAlbums();
        IEnumerable<Post> SearchPost(string search);
        IEnumerable<Artist> GetArtistList();
        IEnumerable<Artist> GetArtistListByType(string type);
        IEnumerable<Artist> SearchArtist(string searchTxt);
        Artist GetArtistByName(string name);
        MetaInfo GetUrlMetaInfo(string controller, string action);
    }
}