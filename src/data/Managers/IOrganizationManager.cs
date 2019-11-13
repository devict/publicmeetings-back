using System;
using System.Threading.Tasks;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.Managers
{
    /// <summary>
    /// Defines a contract for storage and retrieval of <see cref="Organization"/> information.
    /// </summary>
    public interface IOrganizationManager
    {
        /// <summary>
        /// Creates a new record in the data source for <paramref name="organization"/>
        /// </summary>
        /// <param name="organization">
        /// The <see name="Organization"/> to create a record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Create(Organization organization);

        /// <summary>
        /// Updates the data in the data source for <paramref name="organization"/>
        /// </summary>
        /// <param name="organization">
        /// The <see name="Organization"/> to update the record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Update(Organization organization);

        /// <summary>
        /// Deletes <paramref name="organization"/> from the data source.
        /// </summary>
        /// <param name="organization">
        /// The <see name="Organization"/> to delete.
        /// </param>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Delete(Organization organization);

        /// <summary>
        /// Retrieves the information for an <see cref="Organization"/> from the data source.
        /// </summary>
        /// <param name="id">
        /// The <see cref="Guid"/> of the <see cref="Organization"/> to retrieve.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="Organization"/> with matching
        /// <paramref name="id"/> if it exists.
        /// </returns>
        Task<DataResult<Organization>> FindById(Guid id);

        /// <summary>
        /// Retrieves all the <see cref="Organization"/>s that <paramref name="user"/> is following.
        /// </summary>
        /// <param name="user">
        /// The <see cref="User"/> to retrieve <see cref="Organization"/> data for.
        /// </param>
        /// <param name="pageRequest">
        /// The page information for the request. Default is null, which retrieves all records.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="Organization"/>s that
        /// <paramref name="user"/> is following, if any.
        /// </returns>
        Task<DataResult<PagedResult<Organization>>> FindByUser(
                User user,
                PageRequest? pageRequest = null);
    }
}
