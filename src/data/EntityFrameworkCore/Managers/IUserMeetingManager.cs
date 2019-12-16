using System.Threading.Tasks;
using DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Managers
{
    internal interface IUserMeetingManager
    {
        /// <summary>
        /// Creates a new record in the data source for <paramref name="user"/>
        /// and <paramref name="meeting"/>.
        /// </summary>
        /// <param name="user">
        /// The <see name="EFUser"/> to create a record for.
        /// </param>
        /// <param name="meeting">
        /// The <see name="EFMeeting"/> to create a record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Create(EFUser user, EFMeeting meeting);

        /// <summary>
        /// Deletes the record in the data source for <paramref name="user"/>
        /// and <paramref name="meeting"/>.
        /// </summary>
        /// <param name="user">
        /// The <see name="EFUser"/> to delete the record for.
        /// </param>
        /// <param name="meeting">
        /// The <see name="EFMeeting"/> to delete the record for.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Delete(EFUser user, EFMeeting meeting);

        /// <summary>
        /// Retrieves all the <see cref="EFMeeting"/>s that <paramref name="user"/> is following.
        /// </summary>
        /// <param name="user">
        /// The <see cref="EFUser"/> to retrieve <see cref="EFMeeting"/> data for.
        /// </param>
        /// <param name="pageRequest">
        /// The page information for the request. Default is null, which retrieves all records.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="EFMeeting"/>s that
        /// <paramref name="user"/> is following, if any.
        /// </returns>
        Task<DataResult<PagedResult<EFMeeting>>> FindByUser(
                EFUser user,
                PageRequest? pageRequest = null);

        /// <summary>
        /// Retrieves all the <see cref="EFUser"/>s that are following <paramref name="meeting"/>.
        /// </summary>
        /// <param name="meeting">
        /// The <see cref="EFMeeting"/> to retrieve <see cref="EFUser"/> data for.
        /// </param>
        /// <param name="pageRequest">
        /// The page information for the request. Default is null, which retrieves all records.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that contains the <see cref="DataResult{TResult}"/>
        /// for the operation. It will have the <see cref="EFUser"/>s that are following
        /// <paramref name="meeting"/>, if any.
        /// </returns>
        Task<DataResult<PagedResult<EFUser>>> FindByMeeting(
                EFMeeting meeting,
                PageRequest? pageRequest = null);
    }
}
