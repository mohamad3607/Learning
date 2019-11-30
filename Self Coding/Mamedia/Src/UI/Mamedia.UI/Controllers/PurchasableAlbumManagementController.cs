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
                //Artist artist = new Artist()
                //{
                //    Name = model.Name,
                //    Biography = model.Biography,
                //    EnglishName = model.EnglishName
                //};
                //var types = model.Types;
                List<ArtistType> typeList = new List<ArtistType>();
                //foreach (int type in types)
                //{
                //    ArtistType artistType = new ArtistType()
                //    {
                //        Artist = artist,
                //        TypeId = type
                //    };
                //    typeList.Add(artistType);
                //}
                //artist.ArtistTypes = typeList;
                //_artistService.CreateArtist(artist);
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
