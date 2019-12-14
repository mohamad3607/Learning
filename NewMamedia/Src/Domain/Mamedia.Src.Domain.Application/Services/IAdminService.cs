using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Application.Services
{
    public interface IAdminService
    {
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetPublishablePosts();
        Post GetPostByUniqueId(string uniqueId);
        Post GetPostById(int id);
        Post EditPost(Post post);
        TrackPost CreateTrackPost(TrackPost post);
        TrackPost CreatePurchasableAlbumPost(PurchasableAlbumPost post);
        Post DeletePost(int id);
        IEnumerable<PostKind> GetAllPostKinds();
        IEnumerable<ArtistType> GetAllArtistTypes();
        IEnumerable<Artist> GetAllArtitsts();
        IEnumerable<TypeOfArtist> GetAllTypeOfArtists();
        Artist CreateArtist(Artist artist);
        Artist GetArtistById(int artistId);
        Artist EditArtist(Artist artist);
    }
}
