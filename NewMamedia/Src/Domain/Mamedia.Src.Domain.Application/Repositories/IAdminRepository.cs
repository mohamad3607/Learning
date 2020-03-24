using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Application.Repositories
{
    public interface IAdminRepository
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPostByUniqueId(string uniqueId);
        Post GetPostById(int id);
        TrackPost CreateTrackPost(TrackPost post);
        TrackPost EditTrackPost(TrackPost post);
       
        PurchasableAlbumPost CreatePurchasableAlbumPost(PurchasableAlbumPost post);
        Post DeletePost(int id);
        IEnumerable<Post> GetPublishablePosts();
        IEnumerable<PostKind> GetAllPostKinds();
        IEnumerable<ArtistType> GetAllArtistTypes();
        IEnumerable<Artist> GetAllArtitsts();
        IEnumerable<TypeOfArtist> GetAllTypeOfArtists();
        Artist CreateArtist(Artist artist);
        Artist GetArtistById(int artistId);
        Artist EditArtist(Artist artist);
        Post EditPost(Post post);
        TrackPost GetTrackPostById(int Id);
        PurchasableAlbumPost GetPAlbumById(int Id);
        PurchasableAlbumPost EditPAlbum(PurchasableAlbumPost post);


        IEnumerable<MetaInfo> GetAllMetas();
        MetaInfo GetMetaById(int id);
        MetaInfo CreateMetaInfo(MetaInfo meta);
        MetaInfo EditMetaInfo(MetaInfo meta);
        bool DeleteMetaInfoById(int id);

    }
}
