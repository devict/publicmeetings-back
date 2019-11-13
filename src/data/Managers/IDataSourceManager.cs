using System;
using System.Threading.Tasks;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.Managers
{
    /// <summary>
    /// Defines a contract for storage and retrieval of <see cref="DataSource"/> information.
    /// </summary>
    public interface IDataSourceManager
    {
        /// <summary>
        /// Creates a new record in the data source for <paramref name="dataSource"/>
        /// </summary>
        /// <param name="dataSource">
        /// The <see name="DataSource"/> to create a record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Create(DataSource dataSource);

        /// <summary>
        /// Updates the data in the data source for <paramref name="dataSource"/>
        /// </summary>
        /// <param name="dataSource">
        /// The <see name="DataSource"/> to update the record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Update(DataSource dataSource);

        /// <summary>
        /// Deletes <paramref name="dataSource"/> from the data source.
        /// </summary>
        /// <param name="dataSource">
        /// The <see name="DataSource"/> to delete.
        /// </param>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Delete(DataSource dataSource);

        /// <summary>
        /// Retrieves the information for an <see cref="DataSource"/> from the data source.
        /// </summary>
        /// <param name="id">
        /// The <see cref="Guid"/> of the <see cref="DataSource"/> to retrieve.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="DataSource"/> with matching
        /// <paramref name="id"/> if it exists.DataSource
        /// </returns>
        Task<DataResult<DataSource>> FindById(Guid id);

        /// <summary>
        /// Retrieves all the <see cref="DataSource"/>s associated with <see cref="Organization"/>
        /// </summary>
        /// <param name="organization">
        /// The <see cref="Organization"/> to retrieve <see cref="DataSource"/> data for.
        /// </param>
        /// <param name="pageRequest">
        /// The page information for the request. Default is null, which retrieves all records.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="DataSource"/>s that
        /// are associated with <paramref name="organization"/>, if any.
        /// </returns>
        Task<DataResult<PagedResult<DataSource>>> FindByOrganization(
                Organization organization,
                PageRequest? pageRequest = null);

        /// <summary>
        /// Retrieves the <see cref="Organization"/> that <paramref name="dataSource"/> belongs to.
        /// </summary>
        /// <param name="dataSource"/>
        /// The <see cref="DataSource"/> to retrieve the <see cref="Organization"/> for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="Organization"/> that
        /// <paramref name="dataSource"/> belongs to.
        /// </returns>
        Task<DataResult<Organization>> GetOrganization(DataSource dataSource);
    }
}
