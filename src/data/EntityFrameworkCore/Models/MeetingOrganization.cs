using System;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models
{
    /// <summary>
    /// Represents the relationship between a <see cref="EFMeeting"/> and an <see cref="EFOrganization"/>.
    /// </summary>
    internal class MeetingOrganization : DatabaseObject
    {
        /// <summary>
        /// Creates a <see cref="MeetingOrganization"/> from an existing record.
        /// </summary>
        public MeetingOrganization(
            Guid id,
            EFMeeting meeting,
            EFOrganization organization) : base(id)
        {
            Meeting = meeting;
            Organization = organization;
        }

        /// <summary>
        /// Create a new <see cref="MeetingOrganization"/>.
        /// </summary>
        public MeetingOrganization(
            EFMeeting meeting,
            EFOrganization organization) : this(
                Guid.NewGuid(),
                meeting,
                organization)
        {

        }

        /// <summary>
        /// Gets or sets the <see cref="EFMeeting"/> the record is associated with.
        /// </summary>
        public EFMeeting Meeting { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="EFOrganization"/> the record is associated with.
        /// </summary>
        public EFOrganization Organization { get; set; }
    }
}
