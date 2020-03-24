﻿using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using Mamedia.Src.UI.Web.Models;
using Mamedia.Src.UI.Web.Models.PostModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace Mamedia.Src.UI.Web.Controllers
{
    public class AdminController : Controller
    {
        IAdminService _service;
        public AdminController(IAdminService service)
        {
            _service = service;

        }
        public IActionResult PostManagement(string currentFilter, string searchString, int? page)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
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
            if (!String.IsNullOrEmpty(searchString))
            {
                postList = postList.Where(s => s.Title.Contains(searchString)).ToList();
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.postList = postList.ToPagedList(pageNumber, pageSize);

            return View(postList);
        }

        [HttpGet]
        public IActionResult CreateTrackPost()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }

            GetPostNeeds();
            TrackCreateViewModel model = new TrackCreateViewModel();
            model.PublishDate = DateTime.Now;
            model.AllowToPublish = true;
            return View(model);
        }

        private void GetPostNeeds()
        {
            ViewBag.Kinds = _service.GetAllPostKinds().Select(at => new SelectListItem
            {
                Value = at.Id.ToString(),
                Text = at.Title
            }).ToList();

            ViewBag.Artists = _service.GetAllArtistTypes().Select(at => new SelectListItem
            {
                Value = at.Id.ToString(),
                Text = at.Artist.Name + "------" + at.Type.Type
            }).ToList();
        }
        [HttpPost]
        public IActionResult CreateTrackPost([Bind] Models.PostModel.TrackCreateViewModel model)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                TrackPost post = new TrackPost()
                {
                    AuthorId = 2,
                    PublishPermission = model.AllowToPublish,
                    Title = model.Title,
                    UniqueId = model.UniqueId,
                    PublishDate = model.PublishDate,
                    CoverPhotoTag = model.CoverPhotoAlterText,
                    CoverPhotoUrl = model.CoverPhotoAddress,
                    Info = new TrackInfo()
                    {
                        Cross = model.Cross,
                        Lyric = model.Lyric,
                    },
                    Links = new List<Link>() {
                        new Link(){ Tilte="دانلود با کیفیت عالی" , UrlForLink=model.Link}
                    },
                    OpusLatinName = model.EnglishName,
                    OpusName = model.Name,
                    PostKindId = model.PostKind,
                    MetaDescription=model.MetaDescription
                };
                var artistList = new List<PostArtist>();
                foreach (int index in model.ArtistTypes)
                {
                    PostArtist type = new PostArtist()
                    {
                        ArtistTypeId = index,
                        Post = post
                    };
                    artistList.Add(type);
                }
                post.Artists = artistList;
                _service.CreateTrackPost(post);
                TempData["Result"] = "OK";
                return RedirectToAction("CreateTrackPost");
            }
            catch (Exception ex)
            {
                TempData["Result"] = ex.Message;
            }
            return RedirectToAction("CreateTrackPost",model);
        }

        [HttpGet]
        public ActionResult ArtistManagement(string currentFilter, string searchString,int? page)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var list = _service.GetAllArtitsts();
            list = list.ToList<Artist>();
            List<Models.ArtistModel.AllViewModel> artistList = new List<Models.ArtistModel.AllViewModel>();
            foreach (Artist artist in list)
            {
                Mamedia.Src.UI.Web.Models.ArtistModel.AllViewModel vm = new Models.ArtistModel.AllViewModel(artist);
                artistList.Add(vm);
            }
           
            if (!String.IsNullOrEmpty(searchString))
            {
                artistList = artistList.Where(s => s.Name.Contains(searchString)
                                       || s.LatinName.ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.postList = artistList.ToPagedList(pageNumber, pageSize);
            return View();
        }

        [HttpGet]
        public ActionResult CreateArtist()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            ViewBag.VTypes = _service.GetAllTypeOfArtists().Select(at => new SelectListItem
            {
                Value = at.Id.ToString(),
                Text = at.Type
            }).ToList();


            return View();

        }

        [HttpPost]
        public ActionResult CreateArtist([Bind] Models.ArtistModel.CreateViewModel model)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                Artist artist = new Artist()
                {
                    Name = model.Name,
                    Bio = model.Biography,
                    LatinName = model.EnglishName,
                    MetaDescription = model.MetaDescription
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
                artist.Types = typeList;
                _service.CreateArtist(artist);
                TempData["Result"] = "OK";

                return RedirectToAction("CreateArtist");
            }
            catch (Exception ex)
            {
                TempData["Result"] = ex.Message;
                return RedirectToAction("CreateArtist");
            }
        }

        [HttpGet("Admin/EditArtist/{artistId}")]
        public ActionResult EditArtist(int artistId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }

            Artist artist = _service.GetArtistById(artistId);

            Mamedia.Src.UI.Web.Models.ArtistModel.CreateViewModel vm = new Models.ArtistModel.CreateViewModel()
            {
                Biography = artist.Bio,
                EnglishName = artist.LatinName,
                Name = artist.Name,
                MetaDescription = artist.MetaDescription,
                Types = artist.Types.Select(t => t.TypeId).ToList()
            };
            ViewBag.VTypes = _service.GetAllTypeOfArtists().Select(at => new SelectListItem
            {
                Value = at.Id.ToString(),
                Text = at.Type,
                Selected = CheckSelection(at.Id, artist.Types)
            }).ToList();
            
            return View(vm);

        }

        [HttpPost]
        public ActionResult EditArtist([Bind] Models.ArtistModel.CreateViewModel model)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                Artist artist = _service.GetArtistById(model.Id);
                artist.Name = model.Name;
                artist.Bio = model.Biography;
                artist.LatinName = model.EnglishName;
                artist.MetaDescription = model.MetaDescription;

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
                artist.Types = typeList;
                _service.EditArtist(artist);
                TempData["Result"] = "OK";

                return RedirectToAction("EditArtist");
            }
            catch (Exception ex)
            {
                TempData["Result"] = ex.Message;
                return RedirectToAction("EditArtist");
            }

        }

        [HttpGet("Admin/EditPost/{postId}")]
        public ActionResult EditPost(int postId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            Post post = _service.GetPostById(postId);
            if (post is TrackPost trackPost)
            {
                return RedirectToAction("EditTrackPost", postId);
            }
            else if(post is PurchasableAlbumPost pAlbum)
            {
                return RedirectToAction("EditPurchasableAlbumPost", postId);
            }

            return View();

        }
        [HttpGet("Admin/EditTrackPost/{postId}")]
        public ActionResult EditTrackPost(int postId)
        {
            TrackPost model = _service.GetTrackPostById(postId);
            TrackCreateViewModel post;
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                 post = new TrackCreateViewModel()
                {
                     Id=model.Id,
                    AllowToPublish = model.PublishPermission,
                    Title = model.Title,
                    UniqueId = model.UniqueId,
                    PublishDate = model.PublishDate,
                    CoverPhotoAlterText = model.CoverPhotoTag,
                    CoverPhotoAddress = model.CoverPhotoUrl,
                    Cross = model.Info.Cross,
                    Lyric = model.Info.Lyric,
                     MetaDescription = model.MetaDescription,
                    Link = model.Links.Select(a => a.UrlForLink).FirstOrDefault(),
                    EnglishName = model.OpusLatinName,
                    Name = model.OpusName,
                    PostKind = model.PostKindId,
                    ArtistTypes = model.Artists.Select(a => a.ArtistTypeId)
                };
                ViewBag.Artists = _service.GetAllArtistTypes().Select(at => new SelectListItem
                {
                    Value = at.Id.ToString(),
                    Text = at.Artist.Name + "------" + at.Type.Type,
                    Selected = CheckPostArtistSelection(at.Id, model.Artists)
                }).ToList();
                ViewBag.Kinds = _service.GetAllPostKinds().Select(at => new SelectListItem
                {
                    Value = at.Id.ToString(),
                    Text = at.Title,
                    Selected = (at.Id == model.PostKindId)
                }).ToList();
                
                return View(post);
            }
            catch (Exception ex)
            {
            }
            return View();


        }

        [HttpPost]
        public ActionResult EditTrackPost([Bind] Models.PostModel.TrackCreateViewModel model)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                TrackPost post = new TrackPost()
                {
                    Id=model.Id,
                    AuthorId = 2,
                    PublishPermission = model.AllowToPublish,
                    Title = model.Title,
                    UniqueId = model.UniqueId,
                    PublishDate = model.PublishDate,
                    CoverPhotoTag = model.CoverPhotoAlterText,
                    CoverPhotoUrl = model.CoverPhotoAddress,
                    MetaDescription = model.MetaDescription,
                    Info = new TrackInfo()
                    {
                        Cross = model.Cross,
                        Lyric = model.Lyric,
                    },
                    Links = new List<Link>() {
                        new Link(){ Tilte="دانلود با کیفیت عالی" , UrlForLink=model.Link}
                    },
                    OpusLatinName = model.EnglishName,
                    OpusName = model.Name,
                    PostKindId = model.PostKind
                };
                var artistList = new List<PostArtist>();
                foreach (int index in model.ArtistTypes)
                {
                    PostArtist type = new PostArtist()
                    {
                        ArtistTypeId = index,
                        Post = post,
                        IsMain=true
                    };
                    artistList.Add(type);
                }
                post.Artists = artistList;
                _service.EditTrackPost(post);
                TempData["Result"] = "OK";
                return RedirectToAction("EditTrackPost");
            }
            catch (Exception ex)
            {
                TempData["Result"] = ex.Message;
            }
            return RedirectToAction("EditTrackPost");
           
        }

        [HttpGet("Admin/DeletePost/{postId}")]
        public ActionResult DeletePost([Bind] int postId)
        {
            Post post = _service.GetPostById(postId);
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }

            ViewBag.PostTitle = post.Title;

            return View();

        }

        [HttpGet]
        public ActionResult CreatePurchasableAlbum()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }

            GetPostNeeds();
            PAlbumCreateViewModel model = new PAlbumCreateViewModel();
            model.PublishDate = DateTime.Now;
            model.AllowToPublish = true;
            return View("CreatePAlbum",model);
        }

        [HttpPost]
        public IActionResult CreatePAlbumPost([Bind] Models.PostModel.PAlbumCreateViewModel model)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                PurchasableAlbumPost post = new PurchasableAlbumPost()
                {
                    AuthorId = 2,
                    PublishPermission = model.AllowToPublish,
                    Title = model.Title,
                    UniqueId = model.UniqueId,
                    PublishDate = model.PublishDate,
                    CoverPhotoTag = model.CoverPhotoAlterText,
                    CoverPhotoUrl = model.CoverPhotoAddress,
                    MetaDescription = model.MetaDescription,
                    Info = new PurchasableAlbumInfo()
                    {
                        Summary = model.Summary,
                        Price = model.Price
                    },
                    Links = new List<Link>() {
                       new Link(){ Tilte=$"خرید قانونی با قیمت {model.Price} تومان" , UrlForLink=model.Link}
                    },
                    OpusLatinName = model.EnglishName,
                    OpusName = model.Name,
                    PostKindId = model.PostKind
                };
                var artistList = new List<PostArtist>();
                foreach (int index in model.ArtistTypes)
                {
                    PostArtist type = new PostArtist()
                    {
                        ArtistTypeId = index,
                        Post = post
                    };
                    artistList.Add(type);
                }
                post.Artists = artistList;
                _service.CreatePurchasableAlbumPost(post);
                TempData["Result"] = "OK";
                return RedirectToAction("CreatePurchasableAlbum");
            }
            catch (Exception ex)
            {
                TempData["Result"] = ex.Message;
            }
            return RedirectToAction("CreatePurchasableAlbum", model);
        }

        [HttpGet("Admin/EditPurchasableAlbumPost/{postId}")]
        public ActionResult EditPurchasableAlbumPost(int postId)
        {
            PurchasableAlbumPost model = _service.GetPAlbumById(postId);
            PAlbumCreateViewModel post;
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                post = new PAlbumCreateViewModel()
                {
                    Id = model.Id,
                    AllowToPublish = model.PublishPermission,
                    Title = model.Title,
                    UniqueId = model.UniqueId,
                    PublishDate = model.PublishDate,
                    CoverPhotoAlterText = model.CoverPhotoTag,
                    CoverPhotoAddress = model.CoverPhotoUrl,
                    Summary = model.Info.Summary,
                    Price = model.Info.Price,
                    MetaDescription = model.MetaDescription,
                    Link = model.Links.Select(a => a.UrlForLink).FirstOrDefault(),
                    EnglishName = model.OpusLatinName,
                    Name = model.OpusName,
                    PostKind = model.PostKindId,
                    ArtistTypes = model.Artists.Select(a => a.ArtistTypeId)
                };
                ViewBag.Artists = _service.GetAllArtistTypes().Select(at => new SelectListItem
                {
                    Value = at.Id.ToString(),
                    Text = at.Artist.Name + "------" + at.Type.Type,
                    Selected = CheckPostArtistSelection(at.Id, model.Artists)
                }).ToList();
                ViewBag.Kinds = _service.GetAllPostKinds().Select(at => new SelectListItem
                {
                    Value = at.Id.ToString(),
                    Text = at.Title,
                    Selected = (at.Id == model.PostKindId)
                }).ToList();

                return View(post);
            }
            catch (Exception ex)
            {
            }
            return View();


        }

        [HttpPost]
        public ActionResult EditPurchasableAlbumPost([Bind] Models.PostModel.PAlbumCreateViewModel model)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                PurchasableAlbumPost post = new PurchasableAlbumPost()
                {
                    Id = model.Id,
                    AuthorId = 2,
                    PublishPermission = model.AllowToPublish,
                    Title = model.Title,
                    UniqueId = model.UniqueId,
                    PublishDate = model.PublishDate,
                    CoverPhotoTag = model.CoverPhotoAlterText,
                    CoverPhotoUrl = model.CoverPhotoAddress,
                    MetaDescription = model.MetaDescription,
                    Info = new PurchasableAlbumInfo()
                    {
                        Summary = model.Summary,
                        Price = model.Price,
                    },
                    Links = new List<Link>() {
                        new Link(){ Tilte=$"خرید قانونی با قیمت {model.Price} تومان" , UrlForLink=model.Link}
                    },
                    OpusLatinName = model.EnglishName,
                    OpusName = model.Name,
                    PostKindId = model.PostKind
                };
                var artistList = new List<PostArtist>();
                foreach (int index in model.ArtistTypes)
                {
                    PostArtist type = new PostArtist()
                    {
                        ArtistTypeId = index,
                        Post = post,
                        IsMain = true
                    };
                    artistList.Add(type);
                }
                post.Artists = artistList;
                _service.EditPAlbum(post);
                TempData["Result"] = "OK";
                return RedirectToAction("EditPurchasableAlbumPost");
            }
            catch (Exception ex)
            {
                TempData["Result"] = ex.Message;
            }
            return RedirectToAction("EditPurchasableAlbumPost");

        }

        [HttpGet]
        public ActionResult MetaInfoManagement()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            var metas = _service.GetAllMetas();
            return View(metas);
        }

        [HttpGet]
        public ActionResult CreateMetaInfo()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            MetaInfo model = new MetaInfo();
            return View(model);

        }

        [HttpPost]
        public IActionResult CreateMetaInfo([Bind] MetaInfo model)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                string[] splt = model.Url.Split("/");
                model.ControllerName = splt[1];
                model.ActionName = splt[2];
                _service.CreateMetaInfo(model);
                TempData["Result"] = "OK";
                return RedirectToAction("CreateMetaInfo");
            }
            catch (Exception ex)
            {
                TempData["Result"] = ex.Message;
            }
            return RedirectToAction("CreateMetaInfo", model);
        }

        [HttpGet]
        public ActionResult EditMetaInfo(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            MetaInfo model = _service.GetMetaById(id);
            return View(model);

        }

        [HttpPost]
        public IActionResult EditMetaInfo([Bind] MetaInfo model)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                string[] splt = model.Url.Split("/");
                model.ControllerName = splt[1];
                model.ActionName = splt[2];
                _service.EditMetaInfo(model);
                TempData["Result"] = "OK";
                return RedirectToAction("EditMetaInfo");
            }
            catch (Exception ex)
            {
                TempData["Result"] = ex.Message;
            }
            return RedirectToAction("EditMetaInfo", model);
        }

        [HttpGet]
        public ActionResult DeleteMetaInfo(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            bool res = _service.DeleteMetaInfoById(id);
            return RedirectToAction("MetaInfoManagement");

        }

        private bool CheckPostArtistSelection(int id, ICollection<PostArtist> artists)
        {
            foreach (PostArtist artist in artists)
            {
                if (artist.ArtistTypeId == id)
                    return true;

            }
            return false;
        }

        private bool CheckSelection(int id, ICollection<ArtistType> types)
        {
            foreach (ArtistType type in types)
            {
                if (type.TypeId == id)
                    return true;
            }
            return false;
        }
    }
}