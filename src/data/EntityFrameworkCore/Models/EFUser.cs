using System;
using System.Collections.Generic;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models
{
    /// <summary>
    /// Represents a <see cref="User"/> accessed via Entity Framework Core.
    /// </summary>
    internal class EFUser : User
    {
        public EFUser(
            Guid id,
            string firstName,
            string lastName,
            string username,
            UserRole role,
            string? email) : base(
                id,
                firstName,
                lastName,
                username,
                role,
                email)
        {

        }

        public EFUser(User user) : this(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Username,
                user.Role,
                user.Email)
        {

        }

        public ICollection<UserOrganization> OrganizationRecords { get; set; } = new HashSet<UserOrganization>();
        public ICollection<UserMeeting> MeetingRecords { get; set; } = new HashSet<UserMeeting>();
    }
}
