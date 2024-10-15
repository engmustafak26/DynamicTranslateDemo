using DynamicTranslate.DB;
using DynamicTranslateDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace DynamicTranslateDemo.DB
{
    public class DummyDBContext : DbContext
    {
        public DbSet<MasterLookup> MasterLookups { get; set; }
        public DbSet<ChildLookup> ChildLookups { get; set; }
        public DummyDBContext(DbContextOptions<DummyDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddTranslationConfiguration();
            modelBuilder.Entity<MasterLookup>().HasData(
                [
                new MasterLookup{Id=1,Name = "Software Companies"},
                new MasterLookup{Id=2,Name = "Countries"},
                ]);

            modelBuilder.Entity<ChildLookup>().HasData(
               [
                    new ChildLookup {Id=1, Name="Microsoft", MasterLookupId=1},
                    new ChildLookup {Id=2, Name="Oracle", MasterLookupId=1},
                    new ChildLookup {Id=3, Name="Others", MasterLookupId=1},

                    new ChildLookup {Id=4, Name="Egypt",MasterLookupId=2},
                    new ChildLookup {Id=5, Name="Palestine",MasterLookupId=2},
                    new ChildLookup { Id=6,Name="Saudi Arabia",MasterLookupId=2},
                ]);
        }



    }
}
