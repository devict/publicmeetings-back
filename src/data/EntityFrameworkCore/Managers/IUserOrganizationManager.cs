using System.Threading.Tasks;
using DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Managers
{
    internal interface IUserOrganizationManager
    {
        /// <summary>
        /// Creates a new record in the data source for <paramref name="user"/>
        /// and <paramref name="organization"/>.
        /// </summary>
        /// <param name="user">
        /// The <see name="EFUser"/> to create a record for.
        /// </param>
        /// <param name="organization">
        /// The <see name="EFOrganization"/> to create a record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Create(EFUser user, EFOrganization organization);

        /// <summary>
        /// Deletes the record in the data source for <paramref name="user"/>
        /// and <paramref name="organization"/>.
        /// </summary>
        /// <param name="user">
        /// The <see name="EFUser"/> to delete the record for.
        /// </param>
        /// <param name="organization">
        /// The <see name="EFOrganization"/> to delete the record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Delete(EFUser user, EFOrganization organization);

        /// <summary>
        /// Retrieves all the <see cref="EFOrganization"/>s that <paramref name="user"/> is following.
        /// </summary>
        /// <param name="user">
        /// The <see cref="EFUser"/> to retrieve <see cref="EFOrganization"/> data for.
        /// </param>
        /// <param name="pageRequest">
        /// The page information for the request. Default is null, which retrieves all records.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="EFOrganization"/>s that
        /// <paramref name="user"/> is following, if any.
        /// </returns>
        Task<DataResult<PagedResult<EFOrganization>>> FindByUser(
                EFUser user,
                PageRequest? pageRequest = null);

        /// <summary>
        /// Retrieves all the <see cref="EFUser"/>s that are following <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">
        /// The <see cref="EFOrganization"/> to retrieve <see cref="EFUser"/> data for.
        /// </param>
        /// <param name="pageRequest">
        /// The page information for the request. Default is null, which retrieves all records.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="EFUser"/>s that are following
        /// <paramref name="organization"/>, if any.
        /// </returns>
        Task<DataResult<PagedResult<EFUser>>> FindByOrganization(
                EFOrganization organization,
                PageRequest? pageRequest = null);
    }
}
