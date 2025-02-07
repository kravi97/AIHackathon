using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace INTIME.EntityFrameworkCore
{
    public static class INTIMEDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<INTIMEDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<INTIMEDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}