﻿using Mamedia.Src.Domain.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mamedia.Src.UI.Web.Models
{
    public class AllPostsViewModel
    {
        public AllPostsViewModel(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            PublishDate = post.PublishDate;
            UniqueId = post.UniqueId;
            AllowToPublish = post.PublishPermission;
            PostKind = post.PostKind.Title;
            MetaDescription = post.MetaDescription;
        }

        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "اجازه انتشار")]
        public bool AllowToPublish { get; set; }

        [Display(Name = "تاریخ انتشار")]
        public DateTime PublishDate { get; set; }
       

        [Display(Name = "آدرس یکتا")]
        public string UniqueId { get; set; }

        [Display(Name = "نوع نوشته")]
        public string PostKind { get; set; }

        [Display(Name = "MetaDescription")]
        public string MetaDescription { get; set; }



    }
}
