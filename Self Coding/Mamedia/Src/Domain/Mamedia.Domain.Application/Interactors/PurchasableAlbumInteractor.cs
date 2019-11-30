using Mamedia.Domain.Application.Interfaces;
using Mamedia.Domain.Application.Services;
using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Application.Interactors
{
    public class PurchasableAlbumInteractor : IPurchasableAlbumService
    {
        IPurchaseableAlbumRepository _repository;
        public PurchasableAlbumInteractor(IPurchaseableAlbumRepository repository)
        {
            _repository = repository;
        }
        public PurchasableAlbum Create(PurchasableAlbum album)
        {
            return _repository.Create(album);
        }

        public PurchasableAlbum Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchasableAlbum> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ArtistType> GetArtistTypes()
        {
            return _repository.GetArtistTypes();
        }

        public PurchasableAlbum GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
