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
        /// A <see cref="Task"/> that contains the <see cref="DataResult"/>
        /// for the operation.
        /// </returns>
        Task<DataResult> Create(User user);
    }
}
