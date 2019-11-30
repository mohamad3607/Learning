using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(MamediaDataContext context)
        {
            InitTypesOfArtist(context);
        }

        private static void InitTypesOfArtist(MamediaDataContext context)
        {
            
        }

        private static void ArtistTypeCreation(MamediaDataContext context)
        {
         
        }

        private static void PostCreation(MamediaDataContext context)
        {
            TrackDownloadLink trackLink1 = new TrackDownloadLink()
            {
                Tilte = "link 320 track1",
                UrlForLink = "Url for track1 link1"
            };
            TrackDownloadLink trackLink2 = new TrackDownloadLink()
            {
                Tilte = "link 128 track1",
                UrlForLink = "Url for track1 link2"
            };
            MovieLink moviePurchaseLink1 = new MovieLink()
            {
                Tilte = "purchase 1080 movie1",
                UrlForLink = "Url for movie1 link1"
            };
            Artist mehran_modiri = new Artist()
            {
                Name = "Mehran Modiri",
                Biography = "No Bio"
            };
            Artist babak_hamidian = new Artist()
            {
                Name = "Babak Hamidian",
                Biography = "Babak's Bio is nothing"
            };



            Track track1 = new Track()
            {
                CoverPhotoAddress = "Track Photo Address",
                CoverPhotoAlterText = "Track Photo Address Alter",
                Cross = "CROSS IS HERE",
                Name = "Track1",

                Lyric = "Track Lyric",

                DownloadLinks = new List<TrackDownloadLink>() { trackLink2 },
                //Singers =new List<Artist> { artist }
            };

            Movie movie = new Movie()
            {
                CoverPhotoAddress = "Track Photo Address",
                CoverPhotoAlterText = "Track Photo Address Alter",
                ProductionCountry = "Iran",

                Name = "Movie 1",

                Summary = "MOVIE SUMMARY",
                ProductionYear = 1398,
            };

            Post trackPost = new Post()
            {
                AllowToPublish = true,
               
                Title = "Track1 Post",
                Track = track1,
                UniqueId = "Unique Id For Post 1"
            };
            Post moviePost = new Post()
            {
                AllowToPublish = true,
                
                Title = "Movie1 Post",
                Movie = movie,
                UniqueId = "Unique Id For Post 2"
            };

            context.Posts.Add(trackPost);
            context.Posts.Add(moviePost);
        }
    }
}
