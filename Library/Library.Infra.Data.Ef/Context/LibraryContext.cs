using Library.Domain.Entities;
using Library.Infra.Data.Ef.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infra.Data.Ef.Context
{
    public class LibraryContext : DbContext
    {
        static LibraryContext()
        {
            Database.SetInitializer(new LibrarySeedInitializer());
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<DemandsForBook> DemandsForBook { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}
