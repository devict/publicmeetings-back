using System;

namespace DevIct.PublicMeetings.Back.Data.Models
{
    public class User : DatabaseObject
    {
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

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Username { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual string? Email { get; set; }
    }

    public enum UserRole
    {
        User = 0,
        Administrator = 100
    }
}
