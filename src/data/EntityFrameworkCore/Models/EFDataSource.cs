using System;
using DevIct.PublicMeetings.Back.Data.Models;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Models
{
    internal class EFDataSource : DataSource
    {
        public EFDataSource(Guid id, string parserOptions) : base(id, parserOptions)
        {

        }

        public EFDataSource(DataSource dataSource) : this(dataSource.Id, dataSource.ParserOptions)
        {

        }

        public EFOrganization Organization { get; set; } = null!;
    }
}
