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
    }
}
