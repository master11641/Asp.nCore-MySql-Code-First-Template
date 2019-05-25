using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MySql.Data.EntityFrameworkCore.Extensions;
namespace Inventory.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options)
    : base(options)
        {
           // Database.Migrate();
        }
        public  DbSet<Goods> Goods { get; set; }
        public  DbSet<Store> Store { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=inventory;user=root;password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Goods>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(e=>e.Store)
                .WithMany(p=>p.Goodses)
                .HasForeignKey(d=>d.StoreId);
            });

            //   modelBuilder.Entity<Book>(entity =>
            //   {
            //     entity.HasKey(e => e.ISBN);
            //     entity.Property(e => e.Title).IsRequired();
            //     entity.HasOne(d => d.Publisher)
            //       .WithMany(p => p.Books);
            //   });
        }
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<InventoryContext>
    {
        public InventoryContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
            var builder = new DbContextOptionsBuilder<InventoryContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            builder.UseMySQL(connectionString);
            return new InventoryContext(builder.Options);
        }
    }

}