using Data.Context.Configuration;
using Data.DataSources;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DatabaseContext: DbContext
    {
        public DbSet<ClientDataSource> Clients { get; set; }
        public DbSet<BooksellDataSource> Booksells { get; set; }
        public DbSet<OrderDataSource> Orders { get; set; }
        public DbSet<CompositionDataSource> Compositions { get; set; }
        
        // N : N
        public DbSet<ActiveOrderDataSource> ActiveOrders { get; set; }
        public DbSet<SelectedCompositionDataSource> SelectedComposition { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host=localhost;Port=5432;Database=bks;Username=postgres;Password=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // [Order] -> N: [ActiveOrder] :N <- [Booksell]
            modelBuilder.Entity<ActiveOrderDataSource>()
                .HasKey(k => new {k.OrderId, k.BooksellId});

            modelBuilder.Entity<ActiveOrderDataSource>()
                .HasOne(sc => sc.Booksell)
                .WithMany(s => s.Orders)
                .HasForeignKey(sc => sc.BooksellId);

            modelBuilder.Entity<ActiveOrderDataSource>()
                .HasOne(sc => sc.Order)
                .WithMany(s => s.Orders)
                .HasForeignKey(sc => sc.OrderId);
            
            // [Booksell] -> N: [SelectedComposition] :N <- [Composition]
            modelBuilder.Entity<SelectedCompositionDataSource>()
                .HasKey(k => new {k.BooksellId, k.CompositionId});

            modelBuilder.Entity<SelectedCompositionDataSource>()
                .HasOne(sc => sc.Booksell)
                .WithMany(s => s.Compositions)
                .HasForeignKey(sc => sc.BooksellId);

            modelBuilder.Entity<SelectedCompositionDataSource>()
                .HasOne(sc => sc.Composition)
                .WithMany(s => s.Compositions)
                .HasForeignKey(sc => sc.CompositionId);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}