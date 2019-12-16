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
        public PageRequest(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        /// <summary>
        /// Gets the page number to retrieve with the request.
        /// </summary>
        public int Page { get; protected set; }

        /// <summary>
        /// Gets the size of page to retrieve.
        /// </summary>
        /// <remarks>
        /// If this is 0 (default), the request will retrieve all records.
        /// </remarks>
        public int PageSize { get; }

        /// <summary>
        /// Gets the number of items to skip.
        /// </summary>
        internal int Skip => (Page - 1) * PageSize;
    }
}
