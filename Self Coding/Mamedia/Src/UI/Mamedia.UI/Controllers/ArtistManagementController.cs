using Mamedia.Domain.Application.Services;
using Mamedia.Domain.Core.Entities;
using Mamedia.UI.Models.ArtistModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mamedia.UI.Controllers
{
    public class ArtistManagementController : Controller
    {
        IArtistService _artistService;
        public ArtistManagementController(IArtistService service)
        {
            _artistService = service;
        }

        public IActionResult Index()
        {
            var artistList = _artistService.GetAllArtists();
            List<AllViewModel> finalList = new List<AllViewModel>();
            foreach (Artist row in artistList)
            {
                AllViewModel vm = new AllViewModel(row);
                finalList.Add(vm);
            }


            return View(finalList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.VTypes = _artistService.GetAllTypesOfArtist().Select(at => new SelectListItem
            {
                Value = at.Id.ToString(),
                Text = at.Title
            }).ToList();


            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind] CreateViewModel model)
        {
            try
            {
                Artist artist = new Artist()
                {
                    Name = model.Name,
                    Biography = model.Biography,
                    EnglishName = model.EnglishName
                };
                var types = model.Types;
                List<ArtistType> typeList = new List<ArtistType>();
                foreach (int type in types)
                {
                    ArtistType artistType = new ArtistType()
                    {
                        Artist = artist,
                        TypeId = type
                    };
                    typeList.Add(artistType);
                }
                artist.ArtistTypes = typeList;
                _artistService.CreateArtist(artist);
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
