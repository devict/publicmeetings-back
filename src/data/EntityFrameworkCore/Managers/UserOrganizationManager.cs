using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Managers
{
    internal class UserOrganizationManager : ManyToManyManager<EFUser, EFOrganization, UserOrganization>,
        IUserOrganizationManager
    {
        public UserOrganizationManager(Context context, ILogger<UserOrganizationManager> logger)
            : base(context, logger)
        {

        }

        protected override DbSet<UserOrganization> _table => _context.UserOrganizations;

        protected override Expression<Func<UserOrganization, EFUser>> _getA =>
            rec => rec.User;

        protected override Expression<Func<UserOrganization, EFOrganization>> _getB =>
            rec => rec.Organization;

        protected override Expression<Func<UserOrganization, bool>> MatchRecord(EFUser user)
        {
            return rec => rec.User.Id == user.Id;
        }

        protected override Expression<Func<UserOrganization, bool>> MatchRecord(EFOrganization organization)
        {
            return rec => rec.Organization.Id == organization.Id;
        }

        protected override Expression<Func<UserOrganization, bool>> MatchRecord(
                EFUser user,
                EFOrganization organization)
        {
            return rec => rec.User.Id == user.Id && rec.Organization.Id == organization.Id;
        }

        protected override UserOrganization NewJunction(EFUser user, EFOrganization organization)
        {
            return new UserOrganization(user, organization);
        }

        public Task<DataResult<PagedResult<EFUser>>> FindByOrganization(
                EFOrganization organization,
                PageRequest? pageRequest = null)
        {
            return FindByB(organization, pageRequest);
        }

        public Task<DataResult<PagedResult<EFOrganization>>> FindByUser(
                EFUser user,
                PageRequest? pageRequest = null)
        {
            return FindByA(user, pageRequest);
        }
    }
}
