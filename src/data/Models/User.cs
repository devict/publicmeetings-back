using System;

namespace DevIct.PublicMeetings.Back.Data.Models
{
    /// <summary>
    /// Represents a system user.
    /// </summary>
    public class User : DatabaseObject
    {
        /// <summary>
        /// Creates a <see cref="User"/> from an existing record.
        /// </summary>
        public User(
            Guid id,
            string first,
            string last,
            string username,
            UserRole role,
            string? email = null) : base(id)
        {
            FirstName = first;
            LastName = last;
            Username = username;
            Role = role;
            Email = email;
        }

        /// <summary>
        /// Creates a new <see cref="User"/>.
        /// </summary>
        public User(
            string first,
            string last,
            string username,
            UserRole role,
            string? email = null) : this(
                Guid.NewGuid(),
                first,
                last,
                username,
                role,
                email)
        {

        }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user's username.
        /// </summary>
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the user's role.
        /// </summary>
        public virtual UserRole Role { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        public virtual string? Email { get; set; }
    }

    /// <summary>
    /// Represents a role that <see cref="Models.User"/>s can have in the system.
    /// </summary>
    public enum UserRole
    {
        User = 0,
        Administrator = 100
    }
}
