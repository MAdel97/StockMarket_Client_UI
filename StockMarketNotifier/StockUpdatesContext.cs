
using StockMarketNotifier.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockMarketNotifier.Models;

namespace StockUpdates.Context

    {
        public partial class StockUpdatesContext : DbContext 
        {
            public StockUpdatesContext()
            {
            }

            public StockUpdatesContext(DbContextOptions<StockUpdatesContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Stock> Stocks { get; set; }
            public virtual DbSet<Client> Clients { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MAdel\\SQLEXPRESS;Database=StockClient;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
            

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Stocks");

                entity.Property(e => e.c).HasColumnName("close_price");

                entity.Property(e => e.h).HasColumnName("highest_price");

                entity.Property(e => e.l).HasColumnName("lowest_price");

            });
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);   

                entity.ToTable("clients");


            });





            OnModelCreatingPartial(modelBuilder);
            }

            partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        }
    }




