using System;
using System.Collections.Generic;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models
{
    internal class EFOrganization : Organization
    {
        public EFOrganization(
            Guid id,
            string name,
            string? description,
            Address? address) : base(
                id,
                name,
                description,
                address)
        {

        }

        public EFOrganization(Organization organization) : this(
            organization.Id,
            organization.Name,
            organization.Description,
            organization.Address)
        {

        }

        public ICollection<EFDataSource> DataSources { get; set; } = new HashSet<EFDataSource>();
        public ICollection<EFMeeting> Meetings { get; set; } = new HashSet<EFMeeting>();
        public ICollection<UserOrganization> UserRecords { get; set; } = new HashSet<UserOrganization>();
    }
}
