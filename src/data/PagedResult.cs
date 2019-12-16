using System.Collections.Generic;
using System.Linq;

namespace DevIct.PublicMeetings.Back.Data
{
    /// <summary>
    /// Represents the results of a request for paged data.
    /// </summary>
    /// <typeparam name="TResult">
    /// The concrete type contained in the collection.
    /// </typeparam>
    public class PagedResult<TResult> : List<TResult>
    {
        /// <summary>
        /// Creates a new <see cref="PagedResult{TResult}"/>
        /// </summary>
        /// <param name="results">
        /// The results being returned.
        /// </param>
        /// <param name="pageInfo">
        /// The <see cref="PageInfo"/> for the results.
        /// </param>
        public PagedResult(IEnumerable<TResult> results, PageInfo pageInfo)
            : base(results)
        {
            PageInfo = pageInfo;
        }

        /// <summary>
        /// Creates a new <see cref="PagedResult{TResult}"/> using all returned results.
        /// </summary>
        /// <param name="allResults">
        /// All results of the query performed.
        /// </param>
        /// <param name="request">
        /// The <see cref="PageRequest"/> to trim results to.
        /// </param>
        public PagedResult(IEnumerable<TResult> allResults, PageRequest request)
            : base()
        {
            int total = allResults.Count();
            PageInfo = new PageInfo(request, total);
            AddRange(allResults.Skip(PageInfo.Skip).Take(PageInfo.PageSize));
        }

        /// <summary>
        /// Gets the <see cref="PageInfo"/> for the results returned.
        /// </summary>
        public PageInfo PageInfo { get; }
    }
}
