namespace DevIct.PublicMeetings.Back.Data
{
    /// <summary>
    /// Represents the information about which page was retrieved for a request.
    /// </summary>
    public class PageInfo : PageRequest
    {
        /// <summary>
        /// Creates a new <see cref="PageInfo"/> object.
        /// </summary>
        /// <param name="request">
        /// The <see cref="PageRequest"/> used to retrieve data.
        /// </param>
        /// <param name="total"/>
        /// The total number of results which matched the parameters of the request.
        /// </param>
        /// <param name="page"/>
        /// The actual page number returned. If null, uses the page number of <paramref name="request"/>.
        /// </param>
        public PageInfo(PageRequest request, int total)
            : base(request.Page, request.PageSize)
        {
            Total = total;
            if (Page > Pages)
            {
                Page = Pages;
            }
        }

        /// <summary>
        /// Gets the total number of results which matched the parameters of the request.
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Gets the total number of pages for the results being represented.
        /// </summary>
        public int Pages => (PageSize / Total) + 1;
    }
}
