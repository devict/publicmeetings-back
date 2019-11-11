using System;

namespace DevIct.PublicMeetings.Back.Data.Models
{
    /// <summary>
    /// Represents a URL that belongs to another <see cref="DatabaseObject"/>.
    /// </summary>
    public class Url : DatabaseObject
    {
        public Url(Guid id, Uri uri, UrlType type) : base(id)
        {
            Uri = uri;
            Type = type;
        }

        public Url(Uri uri, UrlType type) : this(Guid.NewGuid(), uri, type)
        {

        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public virtual Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="UrlType"/> of the URL.
        /// </summary>
        public virtual UrlType Type { get; set; }
    }

    public enum UrlType
    {
        General = 0,
        Agenda,
        Minutes
    }
}
