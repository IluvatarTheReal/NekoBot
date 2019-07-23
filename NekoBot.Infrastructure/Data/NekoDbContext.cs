using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NekoBot.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NekoBot.Infrastructure.Data
{
    public class NekoDbContext : DbContext
    {
        public NekoDbContext()
        {
            Database.Migrate();
        }

        public DbSet<ModerationLog> ModerationLogs { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionStringBuilder = new SqliteConnectionStringBuilder() { DataSource = "NekoDb.db" }.ToString();

            var connection = new SqliteConnection(connectionStringBuilder);
            optionsBuilder.UseSqlite(connection);
        }
    }
}
