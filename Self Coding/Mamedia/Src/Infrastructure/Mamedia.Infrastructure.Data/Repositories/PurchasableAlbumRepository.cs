using Mamedia.Domain.Application.Interfaces;
using Mamedia.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mamedia.Infrastructure.Data.Repositories
{
    public class PurchasableAlbumRepository:IPurchaseableAlbumRepository
    {
        MamediaDataContext _context;
        public PurchasableAlbumRepository(MamediaDataContext context)
        {
            _context = context;
        }



        public PurchasableAlbum Create(PurchasableAlbum album)
        {
            var returnTrack = _context.PurchasableAlbums.Add(album).Entity;
            _context.SaveChanges();
            return returnTrack;
        }

        public Track Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchasableAlbum> GetAll()
        {
            return _context.PurchasableAlbums
                .Include(t => t.Artists)
                    .ThenInclude(ta => ta.ArtistType)
                        .ThenInclude(at => at.Artist)
                .OrderByDescending(t => t.Id);
        }

        public IEnumerable<ArtistType> GetArtistTypes()
        {
            return _context.ArtistTypes
                 .Include(at => at.Artist)
                 .Include(at => at.TypeOfArtist)
                 .OrderBy(at => at.Artist.Name);
        }

        public PurchasableAlbum GetById(int id)
        {
            return _context.PurchasableAlbums.Where(t => t.Id == id).FirstOrDefault();
        }

        PurchasableAlbum IPurchaseableAlbumRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
