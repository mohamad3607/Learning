using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mamedia.UI.Models;
using Mamedia.Domain.Application.Services;
using Mamedia.Domain.Core.Entities;

namespace Mamedia.UI.Controllers
{
    public class HomeController : Controller
    {
        IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            var list = _postService.GetPublishablePosts();
           list= list.ToList<Post>();
            List<AllPostsViewModel> postList = new List<AllPostsViewModel>();
            foreach (Post post in list)
            {
                AllPostsViewModel vm = new AllPostsViewModel()
                {
                    AllowToPublish = post.AllowToPublish,
                    PostKind = post.PostKind.ToString(),
                    PublishDate = post.PublishDate,
                    Title = post.Title,
                    UniqueId = post.UniqueId
                };
                postList.Add(vm);
            }
            return View(postList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
