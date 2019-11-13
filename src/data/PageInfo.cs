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
        public PageInfo(PageRequest request, uint total, uint? page = null)
            : base(page ?? request.Page, request.PageSize)
        {
            Total = total;
        }

        /// <summary>
        /// Gets the total number of results which matched the parameters of the request.
        /// </summary>
        public uint Total { get; }
    }
}
