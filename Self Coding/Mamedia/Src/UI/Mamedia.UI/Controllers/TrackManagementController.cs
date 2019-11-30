using Mamedia.Domain.Application.Services;
using Mamedia.Domain.Core.Entities;
using Mamedia.UI.Models;
using Mamedia.UI.Models.TrackModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mamedia.UI.Controllers
{
    public class TrackManagementController : Controller
    {
        ITrackService _trackService;
        public TrackManagementController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        public IActionResult Index()
        {
            var trackList = _trackService.GetAllTracks();
            List<AllTracksViewModel> finalList = new List<AllTracksViewModel>();
            foreach(Track track in trackList)
            {
                AllTracksViewModel vm = new AllTracksViewModel(track);
                finalList.Add(vm);
            }
            return View(finalList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Artists = _trackService.GetAllArtistTypes().Select(at => new SelectListItem
            {
                Value = at.Id.ToString(),
                Text = at.Artist.Name + "------"+at.TypeOfArtist.Title
            }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind] CreateViewModel model)
        {
            try
            {
                

                Track track = new Track()
                {
                    Name = model.Name,
                    Cross = model.Cross,
                    EnglishName = model.EnglishName,
                    CoverPhotoAddress=model.CoverPhotoAddress,
                    CoverPhotoAlterText=model.CoverPhotoAlterText,
                    Lyric=model.Lyric
                };
                List<TrackDownloadLink> links = new List<TrackDownloadLink>();
                TrackDownloadLink link = new TrackDownloadLink()
                {
                    Tilte = "دانلود با کیفیت 320",
                    UrlForLink = model.DownloadLinks,
                    Track = track
                };
                links.Add(link);
               
                var artistList = model.ArtistTypes;
                List<TrackArtist> trackArtists = new List<TrackArtist>();
                foreach (int artist in artistList)
                {
                    TrackArtist trackArtist = new TrackArtist()
                    {
                        ArtistTypeId = artist,
                        Track = track
                    };
                    trackArtists.Add(trackArtist);
                }
                track.TrackArtists = trackArtists;
                track.DownloadLinks = links;
                _trackService.CreateTrack(track);
                TempData["Result"] = "OK";

                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                TempData["Result"] = ex.Message;
                return RedirectToAction("Create");
            }
        }
    }
}