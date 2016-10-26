using Hap.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Hap
{
    using Models.Entities;

    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
            :   base("name=DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
        }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        internal static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CalendarEntry>()
                .HasOptional(e => e.Hirer)
                .WithOptionalDependent()
                ;

            base.OnModelCreating(modelBuilder);

        }
    }
}