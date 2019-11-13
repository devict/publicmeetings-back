namespace DevIct.PublicMeetings.Back.Data
{
    /// <summary>
    /// Represents the info required for a paging request.
    /// </summary>
    public class PageRequest
    {
        /// <summary>
        /// Creates a new <see cref="PageRequest"/> which will retrieve all results.
        /// </summary>
        public PageRequest() : this(1, 0)
        {

        }

        /// <summary>
        /// Creates a new <see cref="PageRequest"/>.
        /// </summary>
        /// <param name="page"/>
        /// The page number to retrieve.
        /// </param>
        /// <param name="pageSize"/>
        /// The size of the pages.
        /// </param>
        public PageRequest(uint page, uint pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        /// <summary>
        /// Gets the page number to retrieve with the request.
        /// </summary>
        public uint Page { get; }

        /// <summary>
        /// Gets the size of page to retrieve.
        /// </summary>
        /// <remarks>
        /// If this is 0 (default), the request will retrieve all records.
        /// </remarks>
        public uint PageSize { get; }
    }
}
