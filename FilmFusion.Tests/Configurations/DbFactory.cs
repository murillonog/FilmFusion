using FilmFusion.Infra.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace FilmFusion.Tests.Configurations
{
    internal static class DbFactory
    {
        internal static ApplicationSqlServerDbContext BuildSqlContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationSqlServerDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            return new ApplicationSqlServerDbContext(options);
        }

        internal static void ClearDb(this ApplicationSqlServerDbContext _context)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
    }
}
