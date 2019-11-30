using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Application.Services
{
    public interface IPurchasableAlbumService
    {
        IEnumerable<PurchasableAlbum> GetAll();
        PurchasableAlbum GetById(int id);
        PurchasableAlbum Create(PurchasableAlbum album);
        PurchasableAlbum Delete(int id);
        IEnumerable<ArtistType> GetArtistTypes();
    }
}
