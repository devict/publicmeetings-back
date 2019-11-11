using System;

namespace DevIct.PublicMeetings.Back.Data.Models
{
    /// <summary>
    /// The base class for all models in the database.
    /// </summary>
    public abstract class DatabaseObject
    {
        protected readonly Guid _id;
        
        /// <summary>
        /// Creates a new <see cref="DatabaseObject"/>.
        /// </summary>
        protected DatabaseObject()
        {
            _id = Guid.NewGuid();
        }

        /// <summary>
        /// Creates a new <see cref="DatabaseObject"/> with <paramref name="id"/>
        /// as its unique ID.
        /// </summary>
        protected DatabaseObject(Guid id)
        {
            _id = id;
        }

        /// <summary>
        /// Gets the <see cref="Guid"/> assigned to the <see cref="DatabaseObject"/>.
        /// </summary>
        public virtual Guid Id => _id;
    }
}
