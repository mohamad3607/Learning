using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using Mamedia.Src.UI.Web.Models;
using Mamedia.Src.UI.Web.Models.PostModel;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Mamedia.Src.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        IAnonymouseService _postService;
        public HomeController(IAnonymouseService postService)
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
        public IActionResult Tracks()
        {
            var list = _postService.GetPublishableTracks();
            list = list.ToList<Post>();
            List<DefaultPagePostsViewModel> postList = new List<DefaultPagePostsViewModel>();
            foreach (Post post in list)
            {
                DefaultPagePostsViewModel vm = new DefaultPagePostsViewModel(post);
                postList.Add(vm);
            }

            return View("Index", postList);
        }
        public IActionResult Albums()
        {
            try
            {
                var list = _postService.GetPublishableAlbums();
                list = list.ToList<Post>();
                List<DefaultPagePostsViewModel> postList = new List<DefaultPagePostsViewModel>();
                foreach (Post post in list)
                {
                    DefaultPagePostsViewModel vm = new DefaultPagePostsViewModel(post);
                    postList.Add(vm);
                }
                return View("Index", postList);
            }
            catch { return RedirectToAction("Index"); }


        }
        [HttpGet("Home/PostKind/{kind}")]
        public IActionResult PostKind(string kind)
        {
            var list = _postService.GetPublishablePostsByKind(kind);
            list = list.ToList<Post>();
            List<DefaultPagePostsViewModel> postList = new List<DefaultPagePostsViewModel>();
            foreach (Post post in list)
            {
                DefaultPagePostsViewModel vm = new DefaultPagePostsViewModel(post);
                postList.Add(vm);
            }
            return View("Index", postList);
        }

        [HttpPost]
        public IActionResult Search([Bind] string str)
        {
            string searchText = "Hassan";
            var list = _postService.SearchPost(searchText);
            list = list.ToList<Post>();
            List<DefaultPagePostsViewModel> postList = new List<DefaultPagePostsViewModel>();
            foreach (Post post in list)
            {
                DefaultPagePostsViewModel vm = new DefaultPagePostsViewModel(post);
                postList.Add(vm);
            }

            return View("Index", postList);
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
        public IActionResult PostDetails(string uniqueId)
        {
            var post = _postService.GetPostByUniqueId(uniqueId);
            if (post is TrackPost)
            {
                var info = _postService.GetTrackInfoByPostId(post.Id);
                TrackPostDetailsViewModel vm = new TrackPostDetailsViewModel(post, info);
                return View("TrackPostDetails", vm);
            }
            PostDetailsViewModel model = new PostDetailsViewModel(post);
            return View(model);
        }
    }
}
