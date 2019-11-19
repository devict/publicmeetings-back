using System;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models
{
    internal class EFUrl : Url
    {
        public EFUrl(Guid id, Uri uri, UrlType type) : base(id, uri, type)
        {

        }

        public EFUrl(Url url) : this(url.Id, url.Uri, url.Type)
        {

        }
    }
}
