using DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore
{
    internal class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public virtual DbSet<EFDataSource> DataSources { get; set; } = null!;
        public virtual DbSet<EFMeeting> Meetings { get; set; } = null!;
        public virtual DbSet<EFOrganization> Organizations { get; set; } = null!;
        public virtual DbSet<EFUrl> Urls { get; set; } = null!;
        public virtual DbSet<EFUser> Users { get; set; } = null!;
        public virtual DbSet<UserMeeting> UserMeetings { get; set; } = null!;
        public virtual DbSet<UserOrganization> UserOrganizations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
