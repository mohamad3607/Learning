using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mamedia.UI.Models;
using Mamedia.Domain.Application.Services;
using Mamedia.Domain.Core.Entities;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mamedia.UI.Models.PostModel;

namespace Mamedia.UI.Controllers
{
    public class PostManagementController : Controller
    {
        IPostService _postService;
        public PostManagementController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            var list = _postService.GetAllPosts();
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
        public IActionResult Create()
        {
            ViewBag.Kinds = _postService.GetAllPostKinds().Select(at => new SelectListItem
            {
                Value = at.Id.ToString(),
                Text = at.Kind
            }).ToList();

            ViewBag.Tracks = _postService.GetAllTracks().Select(at => new SelectListItem
            {
                Value = at.Id.ToString(),
                Text = at.Name
            }).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind] CreateViewModel model)
        {
            try
            {
                Post post = new Post()
                {
                    AllowToPublish = model.AllowToPublish,
                    Title = model.Title,
                    UniqueId = model.UniqueId,
                    PublishDate = model.PublishDate,
                    TrackId=model.TrackId,
                    PostKindId=model.PostKind
                };
                _postService.CreatePost(post);
                TempData["Result"] = "OK";
                return RedirectToAction("Create");
            }
            catch(Exception ex)
            {
                TempData["Result"] = ex.Message;
            }
            return RedirectToAction("Create");
        }
    }
}