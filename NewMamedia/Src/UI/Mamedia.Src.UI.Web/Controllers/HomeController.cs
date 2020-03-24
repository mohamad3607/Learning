using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using Mamedia.Src.UI.Web.Models;
using Mamedia.Src.UI.Web.Models.ArtistModel;
using Mamedia.Src.UI.Web.Models.PostModel;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using X.PagedList;

namespace Mamedia.Src.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        IAnonymouseService _service;
        private readonly string _artistPrefix = "دانلود فول آلبوم ";
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

            GetMetaInfo();

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
            GetMetaInfo();
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
                GetMetaInfo();
                return View("Index");
            }
            catch { return RedirectToAction("Index"); }


        }

        [HttpGet("Home/PostKind/{kind}")]
        public IActionResult PostKind(string kind, int? page)
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
            GetMetaInfo();
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
                ViewBag.MetaInfo = UpdatePageMetaInfo(vm.Title, vm.MetaDescription);
                return View("TrackPostDetails", vm);
            }
            if (post is PurchasableAlbumPost)
            {
                var info = _service.GetPAlbumInfoByPostId(post.Id);
                PAlbumPostDetailsViewModel vm = new PAlbumPostDetailsViewModel(post, info);
                ViewBag.MetaInfo = UpdatePageMetaInfo(vm.Title, vm.MetaDescription);
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
            GetMetaInfo();
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
            GetMetaInfo();
            return View();
        }

        [HttpGet("Home/ArtistDetails/{artistName}")]
        public IActionResult ArtistDetails(string artistName)
        {
            var artist = _service.GetArtistByName(artistName);
            ViewBag.MetaInfo = UpdatePageMetaInfo(_artistPrefix + artistName, artist.MetaDescription);
            return View(artist);
        }

        [HttpGet]
        public IActionResult Search(string strSearch, int? page)
        {
            ViewData["CurrentFilter"] = strSearch;

            var list = _service.SearchPost(strSearch);
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
            GetMetaInfo();
            return View("Index");
        }

        [HttpGet]
        public IActionResult SearchArtist(string strSearch, int? page)
        {
            var artists = _service.SearchArtist(strSearch);
            List<ArtistsListViewModel> artistsList = new List<ArtistsListViewModel>();
            foreach (Artist artist in artists)
            {
                ArtistsListViewModel vm = new ArtistsListViewModel(artist);
                artistsList.Add(vm);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.artistList = artistsList.ToPagedList(pageNumber, pageSize);
            GetMetaInfo();
            return View("Artists");

        }

        public string UpdatePageMetaInfo(ref dynamic metaObject, string controller, string action)
        {
            StringBuilder sbMetaTags = new StringBuilder();
            var metaOfPage = _service.GetUrlMetaInfo(controller, action);
            if (metaOfPage != null)
            {
                metaObject = metaOfPage;
                sbMetaTags.Append("<title>" + metaOfPage.PageTitle + "</title>");
                sbMetaTags.Append(Environment.NewLine);
                sbMetaTags.AppendFormat("<meta name='description' content='{0}' />", metaOfPage.MetaDescription);
            }
            else
            {
                metaObject = metaOfPage;
                sbMetaTags.Append("<title>" + "رسانه مامدیا" + "</title>");
                sbMetaTags.Append(Environment.NewLine);
                // sbMetaTags.AppendFormat("<meta name='description' content='{0}' />", metaOfPage.MetaDescription);

            }
            return sbMetaTags.ToString();
        }
        public string UpdatePageMetaInfo(string pageTitle, string metaDesc)
        {
            StringBuilder sbMetaTags = new StringBuilder();
            sbMetaTags.Append("<title>" + pageTitle + "</title>");
            sbMetaTags.Append(Environment.NewLine);
            sbMetaTags.AppendFormat("<meta name='description' content='{0}' />", metaDesc);
            return sbMetaTags.ToString();
        }

        private void GetMetaInfo()
        {
            var controller = RouteData.Values["controller"].ToString();
            var action = RouteData.Values["action"].ToString();
            ViewBag.MetaInfo = UpdatePageMetaInfo(ref ViewBag.MetaObject, controller, action);
        }
    }
}
