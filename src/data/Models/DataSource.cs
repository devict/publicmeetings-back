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
        public DataSource(Guid id, string parserOptions) : base(id)
        {
            ParserOptions = parserOptions;
        }

        /// <summary>
        /// Creates a new <see cref="DataSource"/>.
        /// </summary>
        public DataSource(string parserOptions) : this(Guid.NewGuid(), parserOptions)
        {

        }

        /// <summary>
        /// Gets or sets the parser options string for the data source.
        /// </summary>
        public virtual string ParserOptions { get; set; }
    }
}
