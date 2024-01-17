using Microsoft.EntityFrameworkCore;
using System;

namespace RockBandsArchive.Data
{
    public class BandDbContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Genre> Genres { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"DataSource = BandDB.db");
        }
    }
}
