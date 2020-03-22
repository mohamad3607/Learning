using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using Mamedia.Src.UI.Web.Models;
using Mamedia.Src.UI.Web.Models.PostModel;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using X.PagedList;

namespace Mamedia.Src.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        IAnonymouseService _postService;
        public HomeController(IAnonymouseService postService)
        {
            _postService = postService;
        }
        public IActionResult Index(int? page)
        {
            var list = _postService.GetPublishablePosts();
            list = list.ToList<Post>();
            List<DefaultPagePostsViewModel> postList = new List<DefaultPagePostsViewModel>();
            foreach (Post post in list)
            {
                DefaultPagePostsViewModel vm = new DefaultPagePostsViewModel(post);
                postList.Add(vm);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.postList = postList.ToPagedList(pageNumber, pageSize);
            return View();
        }
        public IActionResult Tracks(int? page)
        {
            var list = _postService.GetPublishableTracks();
            list = list.ToList<Post>();
            List<DefaultPagePostsViewModel> postList = new List<DefaultPagePostsViewModel>();
            foreach (Post post in list)
            {
                DefaultPagePostsViewModel vm = new DefaultPagePostsViewModel(post);
                postList.Add(vm);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.postList = postList.ToPagedList(pageNumber, pageSize);
            return View("Index");
        }
        public IActionResult Albums(int? page)
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

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                ViewBag.postList = postList.ToPagedList(pageNumber, pageSize);
                return View("Index");
            }
            catch { return RedirectToAction("Index"); }


        }

        [HttpGet("Home/PostKind/{kind}")]
        public IActionResult PostKind(string kind,int? page)
        {
            var list = _postService.GetPublishablePostsByKind(kind);
            list = list.ToList<Post>();
            List<DefaultPagePostsViewModel> postList = new List<DefaultPagePostsViewModel>();
            foreach (Post post in list)
            {
                DefaultPagePostsViewModel vm = new DefaultPagePostsViewModel(post);
                postList.Add(vm);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.postList = postList.ToPagedList(pageNumber, pageSize);
            return View("Index");
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
            if (post is PurchasableAlbumPost)
            {
                var info = _postService.GetPAlbumInfoByPostId(post.Id);
                PAlbumPostDetailsViewModel vm = new PAlbumPostDetailsViewModel(post, info);
                return View("PurchasableAlbumPostDetails", vm);
            }
            PostDetailsViewModel model = new PostDetailsViewModel(post);
            return View(model);
        }
    }
}
