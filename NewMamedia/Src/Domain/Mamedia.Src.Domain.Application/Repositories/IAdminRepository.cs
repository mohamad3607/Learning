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
        MoviePost CreateMoviePost(MoviePost post);
        SeriesPost CreateSeriesPost(SeriesPost post);
        PurchasableAlbumPost CreatePurchasableAlbumPost(PurchasableAlbumPost post);
        Post DeletePost(int id);
        IEnumerable<Post> GetPublishablePosts();
        IEnumerable<PostKind> GetAllPostKinds();
        IEnumerable<ArtistType> GetAllArtistTypes();
        IEnumerable<Artist> GetAllArtitsts();
        IEnumerable<Artist> GetArtistsByType(int type);
        IEnumerable<TypeOfArtist> GetAllTypeOfArtists();
        Artist CreateArtist(Artist artist);
        Artist GetArtistById(int artistId);
        Artist EditArtist(Artist artist);
        Post EditPost(Post post);
        TrackPost GetTrackPostById(int Id);
        PurchasableAlbumPost GetPAlbumById(int Id);
        PurchasableAlbumPost EditPAlbum(PurchasableAlbumPost post);
        MoviePost GetMovieById(int Id);
        SeriesPost GetSeriesById(int Id);
        MoviePost EditMovie(MoviePost post);
        SeriesPost EditSeries(SeriesPost post);
        ArtistType GetArtistType(int artistId, int typeId);
        PostArtist CreatePostArtist(PostArtist postArtist);
        PostArtist DeletePostArtist(int postId, int artistTypeId);
        IEnumerable<MetaInfo> GetAllMetas();
        MetaInfo GetMetaById(int id);
        MetaInfo CreateMetaInfo(MetaInfo meta);
        MetaInfo EditMetaInfo(MetaInfo meta);
        bool DeleteMetaInfoById(int id);
        IEnumerable<PostArtist> GetPostArtistsById(int postId);
    }
}
