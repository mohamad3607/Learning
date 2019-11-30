using Mamedia.Domain.Application.Interfaces;
using Mamedia.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mamedia.Infrastructure.Data.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        MamediaDataContext _context;
        public TrackRepository(MamediaDataContext context)
        {
            _context = context;
        }
        public Track CreateTrack(Track track)
        {
            var returnTrack = _context.Tracks.Add(track).Entity;
            _context.SaveChanges();
            return returnTrack;
        }

        public Track DeleteTrack(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Track> GetAllTracks()
        {
            return _context.Tracks
                .Include(t=>t.TrackArtists)
                    .ThenInclude(ta=>ta.ArtistType)
                        .ThenInclude(at=>at.Artist)
                .OrderByDescending(t => t.Id);
        }

        public IEnumerable<ArtistType> GetArtistTypes()
        {
            return _context.ArtistTypes
                 .Include(at => at.Artist)
                 .Include(at => at.TypeOfArtist)
                 .OrderBy(at => at.Artist.Name);
        }

        public Track GetTrackById(int id)
        {
            return _context.Tracks.Where(t => t.Id == id).FirstOrDefault();
        }

    }
}
