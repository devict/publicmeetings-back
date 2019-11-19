using System;

namespace DevIct.PublicMeetings.Back.Data.Models
{
    /// <summary>
    /// Represents an organization with data in the system.
    /// </summary>
    public class Organization : DatabaseObject
    {
        /// <summary>
        /// Creates an <see cref="Organization"/> from an existing record.
        /// </summary>
        public Organization(
            Guid id,
            string name,
            string? description = null,
            Address? address = null) : base(id)
        {
            Name = name;
            Description = description;
            Address = address;
        }

        /// <summary>
        /// Creates a new <see cref="Organization"/>.
        /// </summary>
        public Organization(
            string name,
            string? description = null,
            Address? address = null) : this(
                Guid.NewGuid(),
                name,
                description,
                address)
        {

        }

        /// <summary>
        /// Gets or sets the name of the organization.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets a brief description of the organization.
        /// </summary>
        public virtual string? Description { get; set; }

        /// <summary>
        /// Gets or sets the location of the organization.
        /// </summary>
        public virtual Address? Address { get; set; }
    }
}
