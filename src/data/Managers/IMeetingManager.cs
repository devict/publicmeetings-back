using System;
using System.Threading.Tasks;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.Managers
{
    /// <summary>
    /// Defines a contract for storage and retrieval of <see cref="Meeting"/> information.
    /// </summary>
    public interface IMeetingManager
    {
        /// <summary>
        /// Creates a new record in the data source for <paramref name="meeting"/>
        /// </summary>
        /// <param name="meeting">
        /// The <see name="Meeting"/> to create a record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Create(Meeting meeting);

        /// <summary>
        /// Updates the data in the data source for <paramref name="meeting"/>
        /// </summary>
        /// <param name="meeting">
        /// The <see name="Meeting"/> to update the record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Update(Meeting meeting);

        /// <summary>
        /// Deletes <paramref name="meeting"/> from the data source.
        /// </summary>
        /// <param name="meeting">
        /// The <see name="Meeting"/> to delete.
        /// </param>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Delete(Meeting meeting);

        /// <summary>
        /// Retrieves the information for an <see cref="Meeting"/> from the data source.
        /// </summary>
        /// <param name="id">
        /// The <see cref="Guid"/> of the <see cref="Meeting"/> to retrieve.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="Meeting"/> with matching
        /// <paramref name="id"/> if it exists.Meeting
        /// </returns>
        Task<DataResult<Meeting>> FindById(Guid id);

        /// <summary>
        /// Retrieves all the <see cref="Meeting"/>s associated with <see cref="Organization"/>
        /// </summary>
        /// <param name="organization">
        /// The <see cref="Organization"/> to retrieve <see cref="Meeting"/> data for.
        /// </param>
        /// <param name="pageRequest">
        /// The page information for the request. Default is null, which retrieves all records.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="Meeting"/>s that
        /// are associated with <paramref name="organization"/>, if any.
        /// </returns>
        Task<DataResult<PagedResult<Meeting>>> FindByOrganization(
                Organization organization,
                PageRequest? pageRequest = null);

        /// <summary>
        /// Retrieves all the <see cref="Meeting"/>s that <paramref name="user"/> is following.
        /// </summary>
        /// <param name="user">
        /// The <see cref="User"/> to retrieve <see cref="Meeting"/> data for.
        /// </param>
        /// <param name="pageRequest">
        /// The page information for the request. Default is null, which retrieves all records.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="Meeting"/>s that
        /// <paramref name="user"/> is following, if any.
        /// </returns>
        Task<DataResult<PagedResult<Meeting>>> FindByUser(
                User user,
                PageRequest? pageRequest = null);

        /// <summary>
        /// Retrieves the <see cref="Organization"/> that <paramref name="meeting"/> belongs to.
        /// </summary>
        /// <param name="meeting">
        /// The <see cref="Meeting"/> to retrieve the <see cref="Organization"/> for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="Organization"/> that
        /// <paramref name="meeting"/> belongs to.
        /// </returns>
        Task<DataResult<Organization>> GetOrganization(Meeting meeting);

        /// <summary>
        /// Retrieves all the <see cref="Url"/>s associated with <paramref name="meeting"/>
        /// of <paramref name="type"/>.
        /// </summary>
        /// <param name="meeting">
        /// The <see cref="Meeting"/> to retrieve <see cref="Url"/>s for.
        /// </param>
        /// <param name="type">
        /// The <see cref="UrlType"/> of <see cref="Url"/>s to retrieve.
        /// If null (default), retrieves all <see cref="Url"/>s.
        /// </param>
        /// <param name="pageRequest">
        /// The page information for the request. Default is null, which retrieves all records.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="Url"/>s that
        /// associated with <paramref name="meeting"/> of <paramref name="type"/>, if any.
        /// </returns>
        Task<DataResult<PagedResult<Url>>> GetUrls(
                Meeting meeting,
                UrlType? type = null,
                PageRequest? pageRequest = null);

        /// <summary>
        /// Adds <paramref name="url"/> to the list of <see cref="Url"/>s for
        /// <paramref name="meeting"/>.
        /// </summary>
        /// <param name="meeting">
        /// The <see cref="Meeting"/> to add <paramref name="url"/> to.
        /// </param>
        /// <param>
        /// The <see cref="Url"/> to add to <paramref name="meeting"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> AddUrl(Meeting meeting, Url url);

        /// <summary>
        /// Removes <paramref name="url"/> from the list of <see cref="Url"/>s for
        /// <paramref name="meeting"/>.
        /// </summary>
        /// <param name="meeting">
        /// The <see cref="Meeting"/> to remove <paramref name="url"/> from.
        /// </param>
        /// <param>
        /// The <see cref="Url"/> to remove from <paramref name="meeting"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> RemoveUrl(Meeting meeting, Url url);
    }
}
