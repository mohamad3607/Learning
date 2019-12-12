﻿using Mamedia.Src.Domain.Core.Entities;
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
        TrackPost CreatePurchasableAlbumPost(PurchasableAlbumPost post);
        Post DeletePost(int id);
        IEnumerable<Post> GetPublishablePosts();
        IEnumerable<PostKind> GetAllPostKinds();
        IEnumerable<ArtistType> GetAllArtistTypes();
       
    }
}