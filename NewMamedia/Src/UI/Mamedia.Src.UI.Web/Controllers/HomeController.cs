using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using Mamedia.Src.UI.Web.Models;
using Mamedia.Src.UI.Web.Models.ArtistModel;
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
        IAnonymouseService _service;
        public HomeController(IAnonymouseService postService)
        {
            _service = postService;
        }
        public IActionResult Index(int? page)
        {
            var list = _service.GetPublishablePosts();
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
            var list = _service.GetPublishableTracks();
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
                var list = _service.GetPublishableAlbums();
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
            var list = _service.GetPublishablePostsByKind(kind);
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
            var post = _service.GetPostByUniqueId(uniqueId);
            if (post is TrackPost)
            {
                var info = _service.GetTrackInfoByPostId(post.Id);
                TrackPostDetailsViewModel vm = new TrackPostDetailsViewModel(post, info);
                return View("TrackPostDetails", vm);
            }
            if (post is PurchasableAlbumPost)
            {
                var info = _service.GetPAlbumInfoByPostId(post.Id);
                PAlbumPostDetailsViewModel vm = new PAlbumPostDetailsViewModel(post, info);
                return View("PurchasableAlbumPostDetails", vm);
            }
            PostDetailsViewModel model = new PostDetailsViewModel(post);
            return View(model);
        }

        public IActionResult Artists(int? page)
        {
            var artists = _service.GetArtistList();
            List<ArtistsListViewModel> artistsList = new List<ArtistsListViewModel>();
            foreach (Artist artist in artists)
            {
                ArtistsListViewModel vm = new ArtistsListViewModel(artist);
                artistsList.Add(vm);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.artistList = artistsList.ToPagedList(pageNumber, pageSize);
            return View();
        }

        [HttpGet("Home/Artists/Type/{type}")]
        public IActionResult Artists(string type, int? page)
        {
            var artists = _service.GetArtistListByType(type);
            List<ArtistsListViewModel> artistsList = new List<ArtistsListViewModel>();
            foreach (Artist artist in artists)
            {
                ArtistsListViewModel vm = new ArtistsListViewModel(artist);
                artistsList.Add(vm);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.artistList = artistsList.ToPagedList(pageNumber, pageSize);
            return View();
        }

        [HttpGet("Home/ArtistDetails/{artistName}")]
        public IActionResult ArtistDetails(string artistName)
        {
            var artist = _service.GetArtistByName(artistName);
            return View(artist);
        }
    }
}
