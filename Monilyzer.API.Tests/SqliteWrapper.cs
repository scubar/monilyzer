using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Monilyzer.API.Data;

namespace Monilyzer.API.Tests
{
    public class SqliteWrapper : IDisposable
    {
        SqliteConnection connection;
        DbContextOptions<MonilyzerContext> dbContextOptions;

        public SqliteWrapper(bool seed = false)
        {
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<MonilyzerContext>()
                .UseSqlite(connection)
                .Options;

            // Create the schema
            using (var context = GetContext())
            {
                context.Database.EnsureCreated();
                if (seed) ContextInitializer.Initialize(context);
            }
        }

        /// <summary>
        /// Returns a Monilyzer Context.
        /// </summary>
        /// <returns>Monilyzer Context</returns>
        public MonilyzerContext GetContext()
        {
            return new MonilyzerContext(dbContextOptions); 
        }


        public void Dispose()
        {
            connection.Close(); 
        }
    }
}
