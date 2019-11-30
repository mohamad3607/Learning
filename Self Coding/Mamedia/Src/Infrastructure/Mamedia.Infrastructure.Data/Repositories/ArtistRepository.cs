using Mamedia.Domain.Application.Interfaces;
using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mamedia.Infrastructure.Data.Repositories
{
    public class ArtistRepository:IArtistRepository
    {
        MamediaDataContext _context;
        public ArtistRepository(MamediaDataContext context)
        {
            _context = context;
        }
        public Artist CreateArtist(Artist artist)
        {
            var returnArtist = _context.Artists.Add(artist).Entity;
            _context.SaveChanges();
            return returnArtist;
        }

        public Artist DeleteArtist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return _context.Artists
                .OrderBy(t => t.Name);
        }

        public IEnumerable<TypeOfArtist> GetAllTypesOfArtist()
        {
            return _context.TypeOfArtists;
        }

        public Artist GetArtistById(int id)
        {
            return _context.Artists.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
