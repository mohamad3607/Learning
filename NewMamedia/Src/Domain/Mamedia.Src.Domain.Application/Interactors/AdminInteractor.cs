﻿using Mamedia.Src.Domain.Application.Repositories;
using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Application.Interactors
{
    public class AdminInteractor : IAdminService
    {
        IAdminRepository _repository;
        public AdminInteractor(IAdminRepository repository)
        {
            _repository = repository;
        }

        public Artist CreateArtist(Artist artist)
        {
            return _repository.CreateArtist(artist);
        }

        public PurchasableAlbumPost CreatePurchasableAlbumPost(PurchasableAlbumPost post)
        {
            return _repository.CreatePurchasableAlbumPost(post);
        }

        public TrackPost CreateTrackPost(TrackPost post)
        {
            return _repository.CreateTrackPost(post);
        }

        public Post DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public Artist GetArtistById(int artistId)
        {
            return _repository.GetArtistById(artistId);
        }

        public IEnumerable<ArtistType> GetAllArtistTypes()
        {
            return _repository.GetAllArtistTypes();
        }

        public IEnumerable<Artist> GetAllArtitsts()
        {
            return _repository.GetAllArtitsts();
        }

        public IEnumerable<PostKind> GetAllPostKinds()
        {
            return _repository.GetAllPostKinds();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _repository.GetAllPosts();
        }

        public IEnumerable<TypeOfArtist> GetAllTypeOfArtists()
        {
            return _repository.GetAllTypeOfArtists();
        }

        public Post GetPostById(int id)
        {
            return _repository.GetPostById(id);
        }

        public Post GetPostByUniqueId(string uniqueId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPublishablePosts()
        {
            throw new NotImplementedException();
        }

        public Artist EditArtist(Artist artist)
        {
            return _repository.EditArtist(artist);
        }

        public Post EditPost(Post post)
        {
            throw new NotImplementedException();
        }

        public TrackPost GetTrackPostById(int Id)
        {
            return _repository.GetTrackPostById(Id);
        }

        public TrackPost EditTrackPost(TrackPost post)
        {
            return _repository.EditTrackPost(post);
        }

        public PurchasableAlbumPost GetPAlbumById(int Id)
        {
            return _repository.GetPAlbumById(Id);
        }

        public PurchasableAlbumPost EditPAlbum(PurchasableAlbumPost post)
        {
            return _repository.EditPAlbum(post);
        }

        public IEnumerable<MetaInfo> GetAllMetas()
        {
            return _repository.GetAllMetas();
        }

        public MetaInfo GetMetaById(int id)
        {
            return _repository.GetMetaById(id);
        }

        public MetaInfo CreateMetaInfo(MetaInfo meta)
        {
            return _repository.CreateMetaInfo(meta);
        }

        public MetaInfo EditMetaInfo(MetaInfo meta)
        {
            return _repository.EditMetaInfo(meta);
        }

        public bool DeleteMetaInfoById(int id)
        {
            return _repository.DeleteMetaInfoById(id);
        }
    }
}
