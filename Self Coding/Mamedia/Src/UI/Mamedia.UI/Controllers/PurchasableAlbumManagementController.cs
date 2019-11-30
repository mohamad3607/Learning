using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mamedia.Domain.Application.Services;
using Mamedia.Domain.Core.Entities;
using Mamedia.UI.Models.PurchasableAlbumModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mamedia.UI.Controllers
{
    public class PurchasableAlbumManagementController : Controller
    {
        IPurchasableAlbumService _service;
        public PurchasableAlbumManagementController(IPurchasableAlbumService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var albumList = _service.GetAll();
            List<AllAlbumsViewModel> finalList = new List<AllAlbumsViewModel>();
            foreach (PurchasableAlbum row in albumList)
            {
                AllAlbumsViewModel vm = new AllAlbumsViewModel(row);
                finalList.Add(vm);
            }


            return View(finalList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Artists = _service.GetArtistTypes().Select(at => new SelectListItem
            {
                Value = at.Id.ToString(),
                Text = at.Artist.Name + "------" + at.TypeOfArtist.Title
            }).ToList();


            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind] CreateViewModel model)
        {
            try
            {


                PurchasableAlbum album = new PurchasableAlbum()
                {
                    Name = model.Name,
                    Summary = model.Summary,
                    EnglishName = model.EnglishName,
                    CoverPhotoAddress = model.CoverPhotoAddress,
                    CoverPhotoAlterText = model.CoverPhotoAlterText,
                };
                List<PurchaseAlbumLink> links = new List<PurchaseAlbumLink>();
                PurchaseAlbumLink link = new PurchaseAlbumLink()
                {
                    Tilte = "دانلود با کیفیت 320",
                    UrlForLink = model.DownloadLinks,
                    Album = album
                };
                links.Add(link);

                var artistList = model.ArtistTypes;
                List<PurchasableAlbumArtists> trackArtists = new List<PurchasableAlbumArtists>();
                foreach (int artist in artistList)
                {
                    PurchasableAlbumArtists albumArtists = new PurchasableAlbumArtists()
                    {
                        ArtistTypeId = artist,
                        PurchasableAlbum = album
                    };
                    trackArtists.Add(albumArtists);
                }
                album.Artists = trackArtists;
                album.PurchaseLinks = links;
                _service.Create(album);
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
