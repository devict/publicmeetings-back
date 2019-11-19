using System;
using System.Collections.Generic;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models
{
    internal class EFMeeting : Meeting
    {
        public EFMeeting(
            Guid id,
            DateTimeOffset date,
            string title,
            string? subtitle,
            Address? address) : base(
                id,
                date,
                title,
                subtitle,
                address)
        {

        }

        public EFMeeting(Meeting meeting) : this(
            meeting.Id,
            meeting.Date,
            meeting.Title,
            meeting.Subtitle,
            meeting.Address)
        {

        }

        public EFOrganization Organization { get; set; }
        public ICollection<UserMeeting> UserRecords { get; set; } = new HashSet<UserMeeting>();
    }
}
