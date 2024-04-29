using Contacts.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.WebAPI {
    public class ApplicationDBContext : DbContext {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Contact>().HasKey()
        //}

    }
}
