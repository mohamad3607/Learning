using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using Mamedia.Src.UI.Web.Models;
using Mamedia.Src.UI.Web.Models.PostModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
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
        public ActionResult ArtistManagement()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            var list = _service.GetAllArtitsts();
            list = list.ToList<Artist>();
            List<Models.ArtistModel.AllViewModel> artistList = new List<Models.ArtistModel.AllViewModel>();
            foreach (Artist artist in list)
            {
                Mamedia.Src.UI.Web.Models.ArtistModel.AllViewModel vm = new Models.ArtistModel.AllViewModel(artist);
                artistList.Add(vm);
            }
            return View(artistList);
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
                    LatinName = model.EnglishName
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