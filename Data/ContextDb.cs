using API_REST_PROYECT.Models;
using Microsoft.EntityFrameworkCore;

namespace API_REST_PROYECT.Data
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Glass> Glasses { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de herencia con discriminador
            modelBuilder.Entity<Supply>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Supply>("Supply")
                .HasValue<Profile>("Profile");

            base.OnModelCreating(modelBuilder);
        }
    }
}
