using System;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models
{
    /// <summary>
    /// Represents a record of a <see cref="EFUser"/> following an <see cref="EFMeeting"/>
    /// </summary>
    internal class UserMeeting : DatabaseObject
    {
        /// <summary>
        /// Creates a <see cref="UserMeeting"/> from an existing record.
        /// </summary>
        public UserMeeting(
            Guid id,
            EFUser user,
            EFMeeting meeting) : base(id)
        {
            User = user;
            Meeting = meeting;
        }

        /// <summary>
        /// Create a new <see cref="UserMeeting"/>.
        /// </summary>
        public UserMeeting(
            EFUser user,
            EFMeeting meeting) : this(
                Guid.NewGuid(),
                user,
                meeting)
        {

        }

        /// <summary>
        /// Gets or sets the <see cref="EFUser"/> the record is associated with.
        /// </summary>
        public EFUser User { get; set; }


        /// <summary>
        /// Gets or sets the <see cref="EFMeeting"/> the record is associated with.
        /// </summary>
        public EFMeeting Meeting { get; set; }
    }
}
