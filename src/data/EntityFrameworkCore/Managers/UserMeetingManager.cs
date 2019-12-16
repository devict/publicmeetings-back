using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Managers
{
    internal class UserMeetingManager : ManyToManyManager<EFUser, EFMeeting, UserMeeting>,
        IUserMeetingManager
    {
        public UserMeetingManager(Context context, ILogger<UserMeetingManager> logger)
            : base(context, logger)
        {

        }

        protected override DbSet<UserMeeting> _table => _context.UserMeetings;

        protected override Expression<Func<UserMeeting, EFUser>> _getA =>
            rec => rec.User;

        protected override Expression<Func<UserMeeting, EFMeeting>> _getB =>
            rec => rec.Meeting;

        protected override Expression<Func<UserMeeting, bool>> MatchRecord(EFUser user)
        {
            return rec => rec.User.Id == user.Id;
        }

        protected override Expression<Func<UserMeeting, bool>> MatchRecord(EFMeeting meeting)
        {
            return rec => rec.Meeting.Id == meeting.Id;
        }

        protected override Expression<Func<UserMeeting, bool>> MatchRecord(EFUser user, EFMeeting meeting)
        {
            return rec => rec.User.Id == user.Id && rec.Meeting.Id == meeting.Id;
        }

        protected override UserMeeting NewJunction(EFUser user, EFMeeting meeting)
        {
            return new UserMeeting(user, meeting);
        }

        public Task<DataResult<PagedResult<EFUser>>> FindByMeeting(
            EFMeeting meeting,
            PageRequest? pageRequest = null)
        {
            return FindByB(meeting, pageRequest);
        }

        public Task<DataResult<PagedResult<EFMeeting>>> FindByUser(
            EFUser user,
            PageRequest? pageRequest = null)
        {
            return FindByA(user, pageRequest);
        }
    }
}
