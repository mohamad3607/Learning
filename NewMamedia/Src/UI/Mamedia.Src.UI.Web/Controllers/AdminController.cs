using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using Mamedia.Src.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mamedia.Src.UI.Web.Controllers
{
    public class AdminController : Controller
    {
        IAdminService _service;
        public AdminController(IAdminService service)
        {
            _service = service;
        }
        public IActionResult PostManagement()
        {
            var list = _service.GetAllPosts();
            list = list.ToList<Post>();
            List<AllPostsViewModel> postList = new List<AllPostsViewModel>();
            foreach (Post post in list)
            {
                AllPostsViewModel vm = new AllPostsViewModel(post)
                {

                };
                postList.Add(vm);
            }
            return View(postList);
        }

        [HttpGet]
        public IActionResult CreateTrackPost()
        {
            GetPostNeeds();

            return View();
        }

        private void GetPostNeeds()
        {
            ViewBag.Kinds = _service.GetAllPostKinds().Select(at => new SelectListItem
            {
                Value = at.Id.ToString(),
                Text = at.Title
            }).ToList();

            ViewBag.Tracks = _service.GetAllArtistTypes().Select(at => new SelectListItem
            {
                Value = at.Id.ToString()
                Text = at.Artist.Name + "------" + at.Type.Type
            }).ToList();
        }
        //[HttpPost]
        //public IActionResult Create([Bind] CreateViewModel model)
        //{
        //    try
        //    {
        //        Post post = new Post()
        //        {
        //            AllowToPublish = model.AllowToPublish,
        //            Title = model.Title,
        //            UniqueId = model.UniqueId,
        //            PublishDate = model.PublishDate,
        //            TrackId = model.TrackId,
        //            PostKindId = model.PostKind
        //        };
        //        _service.CreatePost(post);
        //        TempData["Result"] = "OK";
        //        return RedirectToAction("Create");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Result"] = ex.Message;
        //    }
        //    return RedirectToAction("Create");
        //}
    }
}