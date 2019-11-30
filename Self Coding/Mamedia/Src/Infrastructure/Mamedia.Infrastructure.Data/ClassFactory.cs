using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Infrastructure.Data
{
    public static class ClassFactory
    {
        public static DownloadLink GetDownloadLinkObject(string title,string url)
        {
            return new TrackDownloadLink();
        }
        public static Post GetPostObject(string title, string url)
        {
            return new Post();
        }
    }
}
