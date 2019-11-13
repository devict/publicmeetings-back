using System;
using System.Threading.Tasks;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.Managers
{
    /// <summary>
    /// Defines a contract for storage and retrieval of <see cref="User"/> information.
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Creates a new record in the data source for <paramref name="user"/>
        /// </summary>
        /// <param name="user">
        /// The <see name="User"/> to create a record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Create(User user);

        /// <summary>
        /// Updates the data in the data source for <paramref name="user"/>
        /// </summary>
        /// <param name="user">
        /// The <see name="User"/> to update the record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Update(User user);

        /// <summary>
        /// Deletes <paramref name="user"/> from the data source.
        /// </summary>
        /// <param name="user">
        /// The <see name="User"/> to delete.
        /// </param>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Delete(User user);

        /// <summary>
        /// Retrieves the information for a <see cref="User"/> from the data source.
        /// </summary>
        /// <param name="id">
        /// The <see cref="Guid"/> of the <see cref="User"/> to retrieve.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="User"/> with matching
        /// <paramref name="id"/> if it exists.
        /// </returns>
        Task<DataResult<User>> FindById(Guid id);
    }
}
