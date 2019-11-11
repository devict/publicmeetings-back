using System;

namespace DevIct.PublicMeetings.Back.Data.Models
{
    /// <summary>
    /// Represents a source of data to parse into the system.
    /// </summary>
    public class DataSource : DatabaseObject
    {
        /// <summary>
        /// Creates a <see cref="DataSource"/> from an existing record.
        /// </summary>
        public DataSource(Guid id, string format) : base(id)
        {
            Format = format;
        }

        /// <summary>
        /// Creates a new <see cref="DataSource"/>.
        /// </summary>
        public DataSource(string format) : this(Guid.NewGuid(), format)
        {

        }

        /// <summary>
        /// Gets or sets the format string for the data source.
        /// </summary>
        public virtual string Format { get; set; }
    }
}
