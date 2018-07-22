using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContactInformationLibrary.Entity
{
    public class AppDbContext : DbContext
    {
        public bool IsDisposed { get; set; }

        public AppDbContext() : base("AppDbContext")
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region ContactInformation

            modelBuilder.Entity<Contact>().Property(t => t.FirstName).HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(t => t.LastName).HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(t => t.Email).HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(t => t.PhoneNumber).HasMaxLength(20);

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            var contacts = new List<Contact>
            {
                new Contact { FirstName = "Peter", LastName = "Clarke", Email = "peter@yahoo.com", PhoneNumber = "09878672343", Status = true},
                new Contact { FirstName = "Jon", LastName = "Roy", Email = "jon@gmail.com", PhoneNumber = "09978552366", Status = true},
                new Contact { FirstName = "Ron", LastName = "Visely", Email = "ron@rediffmail.com", PhoneNumber = "09078672355", Status = true},
                new Contact { FirstName = "Harry", LastName = "Watson", Email = "harry@uk.co", PhoneNumber = "07778672466", Status = true},
                new Contact { FirstName = "Merry", LastName = "Broad", Email = "broad@yahoo.com", PhoneNumber = "08878672365", Status = true},
            };
            contacts.ForEach(x => context.Contacts.Add(x));
            context.SaveChanges();
        }
    }
}
