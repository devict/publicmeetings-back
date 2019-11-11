using System;

namespace DevIct.PublicMeetings.Back.Data.Models
{
    /// <summary>
    /// Represents a meeting of an <see cref="Organization"/>.
    /// </summary>
    public class Meeting : DatabaseObject
    {
        /// <summary>
        /// Creates a <see cref="Meeting"/> from an existing record.
        /// </summary>
        public Meeting(
            Guid id,
            DateTimeOffset date,
            string title,
            string? subtitle = null,
            Address? address = null) : base(id)
        {
            Date = date;
            Title = title;
            Subtitle = subtitle;
            Address = address;
        }

        /// <summary>
        /// Creates a new <see cref="Meeting"/>.
        /// </summary>
        public Meeting(
            DateTimeOffset date,
            string title,
            string? subtitle = null,
            Address? address = null) : this(
                Guid.NewGuid(),
                date,
                title,
                subtitle,
                address)
        {

        }

        /// <summary>
        /// Gets or sets the date and time of the meeting.
        /// </summary>
        public virtual DateTimeOffset Date { get; set; }

        /// <summary>
        /// Gets or sets the title of the meeting.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the subtitle for the meeting.
        /// </summary>
        public virtual string? Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the address of the meeting.
        /// </summary>
        public virtual Address? Address { get; set; }
    }
}
