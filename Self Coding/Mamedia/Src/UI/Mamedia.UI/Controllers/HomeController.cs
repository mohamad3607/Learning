using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mamedia.UI.Models;
using Mamedia.Domain.Application.Services;
using Mamedia.Domain.Core.Entities;
using Mamedia.UI.Models.PostModel;

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
            list = list.ToList<Post>();
            List<DefaultPagePostsViewModel> postList = new List<DefaultPagePostsViewModel>();
            foreach (Post post in list)
            {
                DefaultPagePostsViewModel vm = new DefaultPagePostsViewModel(post);
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
        [HttpGet("Home/PostDetails/{uniqueId}")]
        public IActionResult PostDetails()
        {
            return View();
        }
    }
}
