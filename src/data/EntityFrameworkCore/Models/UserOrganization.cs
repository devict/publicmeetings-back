using System;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models
{
    /// <summary>
    /// Represents a record of a <see cref="EFUser"/> following an <see cref="EFOrganization"/>
    /// </summary>
    internal class UserOrganization : DatabaseObject
    {
        /// <summary>
        /// Creates a <see cref="UserOrganization"/> from an existing record.
        /// </summary>
        public UserOrganization(
            Guid id,
            EFUser user,
            EFOrganization organization) : base(id)
        {
            User = user;
            Organization = organization;
        }

        /// <summary>
        /// Create a new <see cref="UserOrganization"/>.
        /// </summary>
        public UserOrganization(
            EFUser user,
            EFOrganization organization) : this(
                Guid.NewGuid(),
                user,
                organization)
        {

        }

        /// <summary>
        /// Gets or sets the <see cref="EFUser"/> the record is associated with.
        /// </summary>
        public EFUser User { get; set; }


        /// <summary>
        /// Gets or sets the <see cref="EFOrganization"/> the record is associated with.
        /// </summary>
        public EFOrganization Organization { get; set; }
    }
}
