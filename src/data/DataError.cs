using System;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data
{
    /// <summary>
    /// Represents an error that occured while accessing data.
    /// </summary>
    public struct DataError
    {
        /// <summary>
        /// Initializes a <see cref="DataError"/>.
        /// </summary>
        /// <param name="code">
        /// The code for the error.
        /// </param>
        /// <param name="description">
        /// A description of the error.
        /// </param>
        private DataError(uint code, string description)
        {
            Code = code;
            Description = description;
        }

        /// <summary>
        /// Gets the code for the error.
        /// </summary>
        public uint Code { get; }

        /// <summary>
        /// Gets the description of the error.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Creates a generic <see cref="DataError"/>.
        /// </summary>
        /// <param name="description">
        /// A description of the error.
        /// </param>
        /// <remarks>
        /// This method is meant to speed up development. For release builds, 
        /// it is preferred to create a new static method for the type of error 
        /// and assign a code to it. If called in a release build, the compiler
        /// will generate an Obsolete warning.
        /// </remarks>
#if RELEASE
        [Obsolete("This method is meant to speed up development. " +
                "For release builds, it is preferred to create a new static " +
                "method for the type of error and assign a code to it.")]
#endif
        internal static DataError Generic(string description)
        {
            return new DataError(0, description);
        }

        /// <summary>
        /// Creates a new <see cref="DataError"/> when an ID is not found.
        /// </summary>
        /// <param name="id">
        /// The ID that was searched for.
        /// </param>
        /// <param name="type">
        /// The type that was searched for. Default is null.
        /// </param>
        internal static DataError IdNotFound(Guid id, string? type = null)
        {
            return new DataError(1, $"{type ?? "Entity"} with id {id} not found");
        }

        /// <summary>
        /// Creates a new <see cref="DataError"/> when an ID is not found.
        /// </summary>
        /// <param name="item">
        /// The <see cref="DatabaseObject"/> searched for in the database.
        /// </param>
        internal static DataError IdNotFound(DatabaseObject item)
        {
            return IdNotFound(item.Id, item.GetType().Name);
        }
    }
}
