using Microsoft.EntityFrameworkCore;
using SiteLibrary.Entities.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siteManagement.DataAccess
{
    public class AptDbContext:DbContext
    {
        //Burası DataAccess katmanımız bu katmanda EntitiyFramework işlemleri yapılır.
        //Tüm sınıflarımız için DbSet işlemi ve override işlemlerimizi yapmalıyız.
        public AptDbContext(DbContextOptions<AptDbContext> options):base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=SiteManagementDb;Integrated Security=True;");
        }

        //DbSet sayesinde add, remove, update gibi işlemleri yapan metodlara ulaşmış olduk
        public DbSet<Apartment> apts => Set<Apartment>();
        public DbSet<Invoice> invoice => Set<Invoice>();
        public DbSet<User> user => Set<User>();
        public DbSet<Message> messages => Set<Message>();

        public DbSet<Role>  Roles => Set<Role>();

        public DbSet<ApartmentType> ApartmentTypes => Set<ApartmentType>();

        public DbSet<InvoiceType> InvoiceTypes => Set<InvoiceType>();

    }
}
